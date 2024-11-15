﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace FlavorfulStory.InventorySystem.UI.Tooltips
{
    /// <summary> Абстрактный базовый класс, который обрабатывает создание
    /// префаба тултипа в правильном положении на экране относительно курсора.</summary>
    /// <remarks> Переопределите абстрактные методы для своего спавнера тултипа.</remarks>
    public abstract class TooltipSpawner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary> Префаб тултипа, который нужно заспавнить.</summary>
        [Tooltip("Префаб тултипа, который нужно заспавнить.")]
        [SerializeField] private GameObject _tooltipPrefab;

        /// <summary> Заспавненный тултип.</summary>
        private GameObject _tooltip;

        #region Abstract Methods
        /// <summary> Можно ли создать тултип?</summary>
        /// <remarks> Возвращает True, если спавнеру можно создать тултип.</remarks>
        public abstract bool CanCreateTooltip();

        /// <summary> Вызывается, когда приходит время обновить информацию в префабе тултипа.</summary>
        /// <param name="tooltip"> Заспавненный префаб тултипа для обновления.</param>
        public abstract void UpdateTooltip(GameObject tooltip);
        #endregion

        /// <summary> Вызывается при уничтожении объекта.</summary>
        private void OnDestroy() => ClearTooltip();

        /// <summary> Вызывается при отключении объекта.</summary>
        private void OnDisable() => ClearTooltip();

        /// <summary> Очистить тултип.</summary>
        private void ClearTooltip()
        {
            if (_tooltip != null) Destroy(_tooltip);
        }

        /// <summary> Вызывается при наведении курсора на объект UI.</summary>
        /// <remarks> Создает или обновляет тултип при необходимости.</remarks>
        /// <param name="eventData"> Данные события взаимодействия с UI.</param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_tooltip != null && !CanCreateTooltip()) ClearTooltip();

            if (_tooltip == null && CanCreateTooltip())
            {
                var parentCanvas = GetComponentInParent<Canvas>();
                _tooltip = Instantiate(_tooltipPrefab, parentCanvas.transform);
            }

            if (_tooltip != null)
            {
                UpdateTooltip(_tooltip);
                PositionTooltip();
            }
        }

        /// <summary> Позиционировать тултип относительно объекта, на который наведен курсор.</summary>
        /// <remarks> В зависимости от расположения объекта относительно центра экрана
        /// тултип корректируется, чтобы не выходить за границы экрана.</remarks>
        private void PositionTooltip()
        {
            // Обновляем положение всех Canvas-элементов для учета изменений в UI.
            Canvas.ForceUpdateCanvases();

            // Получаем мировые координаты углов тултипа.
            var tooltipCorners = new Vector3[4];
            _tooltip.GetComponent<RectTransform>().GetWorldCorners(tooltipCorners);

            // Получаем мировые координаты углов текущего объекта (слота).
            var slotCorners = new Vector3[4];
            GetComponent<RectTransform>().GetWorldCorners(slotCorners);

            // Определяем местоположение относительно середины экрана.
            bool below = transform.position.y > Screen.height / 2;
            bool right = transform.position.x < Screen.width / 2;

            // Выбираем индекс угла текущего объекта (слота) и тултипа.
            int slotCornerIndex = GetCornerIndex(below, right);
            int tooltipCornerIndex = GetCornerIndex(!below, !right);

            // Устанавливаем новое положение тултипа, чтобы он был выровнен с нужным углом.
            _tooltip.transform.position = slotCorners[slotCornerIndex] - tooltipCorners[tooltipCornerIndex] + _tooltip.transform.position;
        }

        /// <summary> Возвращает индекс угла для позиционирования.</summary>
        /// <param name="below"> Находится ли объект ниже середины экрана?</param>
        /// <param name="right"> Находится ли объект правее середины экрана?</param>
        /// <returns> Индекс угла: 0 - левый нижний, 1 - левый верхний, 2 - правый верхний, 3 - правый нижний.</returns>
        private int GetCornerIndex(bool below, bool right) => (below, right) switch
        {
            (true, false) => 0, // Левый нижний угол
            (false, false) => 1, // Левый верхний угол
            (false, true) => 2, // Правый верхний угол
            (true, true) => 3, // Правый нижний угол
        };

        /// <summary> Вызывается при уводе курсора с объекта UI.</summary>
        /// <param name="eventData"> Данные события взаимодействия с UI.</param>
        public void OnPointerExit(PointerEventData eventData) => ClearTooltip();
    }
}