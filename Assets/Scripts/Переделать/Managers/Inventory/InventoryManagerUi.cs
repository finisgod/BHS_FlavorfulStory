using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary> Менеджер работы с UI инвентаря.</summary>
public class InventoryManagerUI : MonoBehaviour //Покрыть комментариями. Упросить код
{
    /// <summary>Лист из ячеек инвентаря .</summary>
    private List<Cell> cells = new List<Cell>();
    /// <summary>Префаб для ячейки инвентаря .</summary>
    [SerializeField] GameObject _cellPrefab;
    /// <summary>Префаб для счетчика ячейки инвентаря .</summary>
    [SerializeField] GameObject _cellCounter;
    /// <summary>Префаб для окружности вокруг счетчика инвентаря .</summary>
    [SerializeField] GameObject _cellCounterCircle;
    /// <summary>Ширина инвентаря .</summary>
    [SerializeField] int width;
    /// <summary>Высота инвентаря .</summary>
    [SerializeField] int heigh;
    /// <summary>Ширина ячейки инвентаря .</summary>
    [SerializeField] int cellWidth;
    /// <summary>Расстояние между ячейками инвентаря .</summary>
    [SerializeField] int cellInterval;
    /// <summary>Количество колонок инвентаря .</summary>
    [SerializeField] int columns;
    /// <summary>Количество рядов в инвентаре .</summary>
    [SerializeField] int rows;
    /// <summary>Текущая ячейка (для Drag) .</summary>
    private Cell _selectedCell = null;
    /// <summary>Флаг открыт инвентарь на полную или нет.</summary>
    private bool _isFull = true;
    /// <summary>Метод для инициализации инвентаря.</summary>
    private void Start()
    {
        DragDropManager.CellMovedEvent += RefreshSelected; 
        
        Vector3 deltax = new Vector3(cellWidth + cellInterval, 0);
        Vector3 deltay = new Vector3(0, cellWidth + cellInterval);
        Vector3 startPos = new Vector3(-width / 2 + cellWidth / 2 + cellInterval, -heigh / 2 + cellWidth / 2 + cellInterval);

        for (int r = rows - 1; r > -1; r--)
        {
            for (int c = 0; c < columns; c++)
            {
                //Instantiate cell
                GameObject cell = Instantiate(_cellPrefab, transform.position + startPos + deltax * c + deltay * r, transform.rotation, this.transform);
                Cell cellObject = cell.GetComponent<Cell>();
                cells.Add(cellObject);
                cellObject.row = r;
                cellObject.col = c;
                //Instantiate counter in cell
                GameObject cellCounter = Instantiate(_cellCounter, transform.position + startPos + deltax * c + deltay * r, transform.rotation, cell.transform);
                cellCounter.transform.localPosition += new Vector3(10, -9);
                GameObject cellCircle = Instantiate(_cellCounterCircle, transform.position + startPos + deltax * c + deltay * r, transform.rotation, cell.transform);
                //Change DrawOrder
                cellCircle.transform.SetAsLastSibling();
                cellCounter.transform.SetAsLastSibling();               
                //Set Img
                SetUnselectedBorder(cellObject);
            }
        }
    }
    /// <summary>Метод для разворачивания инвентаря из 1строчного представления в полноценное.</summary> 
    public void ToggleFull() //Убрать дублирование кода
    {
        if (_isFull)
        {
            RectTransform transform = this.GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(width, 100);
            transform.anchoredPosition += new Vector2(0, -300);
            _isFull = false;
            foreach (Cell cell in cells)
            {
                if (cell.row != rows - 1)
                {
                    cell.gameObject.SetActive(false);
                }
                else
                {
                    cell.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -heigh / 2 + cellWidth / 2);
                }
            }
        }
        else
        {
            RectTransform transform = this.GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(width, 100);
            transform.anchoredPosition -= new Vector2(0, -300);
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, heigh);
            _isFull = true;
            foreach (Cell cell in cells)
            {
                if (cell.row != rows - 1)
                {
                    cell.gameObject.SetActive(true);
                }
                else
                {
                    cell.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, -heigh / 2 + cellWidth / 2);
                }
            }
        }
    }
    /// <summary>Получение первой свободной ячейки.</summary>
    public Cell GetEmptyCell()
    {
        foreach (Cell cell in cells)
        {
            if (cell.IsEmpty)
            {
                return cell;
            }
        }
        return null;
    }
    /// <summary>Получение первой занятой ячейки.</summary>
    public Cell GetNonEmptyCellToSelect()
    {
        for (int i = 0; i < columns; i++)
        {
            Cell cell = cells[i];
            if (!cell.IsEmpty)
            {
                return cell;
            }
        }
        return null;
    }
    /// <summary>Обновление выбранной ячейки.</summary>
    public void RefreshSelected()
    {
        if (_selectedCell != null)
        {
            if (_selectedCell.IsEmpty)
            {
                SelectNonEmptyCell();
            }
        }
        else
        {
            SelectNonEmptyCell();
        }
    }
    /// <summary>Метод для добавления айтема в UI инвентаря.</summary>
    public bool AddItem(Item item)
    {
        //Prefab logic
        string prefabName = "Prefabs/GameObjects/Inventory/" + item.Name + "_Inventory"; //ToDo: убрать хардкод
        GameObject prefab = (GameObject)Resources.Load(prefabName);
        //
        Cell emptyCell = GetEmptyCell();
        if (emptyCell != null)
        {
            SetCellCounterValue(emptyCell, "1");
            //Get cell GameObject
            GameObject cellForAdd = emptyCell.gameObject;
            //Instantiate object in cell
            GameObject cellItemObject = Instantiate(prefab, cellForAdd.transform);
            //Change DrawOrder
            cellItemObject.transform.SetAsFirstSibling();
            //Make isEmpty flag == false
            emptyCell.IsEmpty = false;
            //Write item in CellItem
            CellItem cellItem = cellItemObject.GetComponent<CellItem>();
            cellItem.Item = item;
            //Return success
            if (_selectedCell == null)
            {
                SelectNonEmptyCell();
            }
            return true;
        }
        else
        {
            //Return err
            return false;
        }
    }
    /// <summary>Получение занятой ячейки.</summary>
    public void SelectNonEmptyCell()
    {
        if (_selectedCell != null)
        {
            SetUnselectedBorder(_selectedCell);
        }
        Cell nonEmptyCell = GetNonEmptyCellToSelect();
        if (nonEmptyCell != null)
        {
            SetCurrentInventoryItem(cells.IndexOf(nonEmptyCell));
        }
        else
        {
            _selectedCell = null;
        }
    }
    /// <summary>Метод для удаления айтема из UI инвентаря.</summary>
    public void RemoveItem(Item item)
    {
        foreach (var cell in cells)
        {
            if (!cell.IsEmpty)
            {
                CellItem cellItem = cell.gameObject.GetComponentInChildren<CellItem>();
                if (cellItem != null)
                {
                    if (cellItem.Item == item)
                    {
                        Destroy(cellItem.gameObject);
                        cell.IsEmpty = true;
                        cellItem.Item = null;
                        SetCellCounterValue(cell, "0");
                        if (cell == _selectedCell)
                        {
                            SetUnselectedBorder(cell);
                            Cell nonEmptyCell = GetNonEmptyCellToSelect();
                            if (nonEmptyCell != null)
                            {
                                SetCurrentInventoryItem(cells.IndexOf(nonEmptyCell));
                            }
                            else
                            {
                                _selectedCell = null;
                            }
                        }
                        return;
                    }
                }
            }
        }
    }
    /// <summary>Изменения значения счетчика. Для эвента</summary>
    public void ChangeItemCount(Item item)
    {
        Cell cell = FindCellByItemName(item.Name);
        if (cell != null)
        {
            int curr = Convert.ToInt32(cells[0].GetComponentInChildren<CellCounter>().gameObject.GetComponent<TMP_Text>().text);
            curr = item.Count;
            SetCellCounterValue(cell, curr.ToString());
        }
    }
    /// <summary>Получение текущего айтема из инвентаря (выбранного).</summary>
    public Item GetCurrentInventoryItem()
    {
        if (_selectedCell != null)
        {
            if (!_selectedCell.IsEmpty)
            {
                CellItem cellItem = _selectedCell.gameObject.GetComponentInChildren<CellItem>();
                return cellItem.Item;
            }
        }
        return null;
    }
    /// <summary>Выбор айтема.</summary>
    public void SetCurrentInventoryItem(int index)
    {
        if (index == -1)
        {
            SetUnselectedBorder(_selectedCell);
            _selectedCell = null;
        }
        if (index < cells.Count)
        {
            Cell cell = cells[index];
            if (cell != null && !cell.IsEmpty)
            {
                if (_selectedCell != null)
                {
                    SetUnselectedBorder(_selectedCell);
                }
                _selectedCell = cell;
                SetSelectedBorder(_selectedCell);

                CellItem cellItem = _selectedCell.gameObject.GetComponentInChildren<CellItem>();
                ItemSelectedChangedEvent?.Invoke(cellItem.Item);
            }
        }
    }
    /// <summary>Установка границы айтема в невыбранное состояние.</summary>
    public void SetUnselectedBorder(Cell selectedCell)
    {
        UnityEngine.UI.Image currCellImg = selectedCell.GetComponent<UnityEngine.UI.Image>();
        currCellImg.color = Color.white;
    }
    /// <summary>Установка границы айтема в выбранное состояние.</summary>
    public void SetSelectedBorder(Cell selectedCell)
    {
        UnityEngine.UI.Image currCellImg = selectedCell.GetComponent<UnityEngine.UI.Image>();
        currCellImg.color = Color.black;
    }
    /// <summary>Получение ячейки инвентаря по имения айтема (первой по очереди).</summary>
    public Cell FindCellByItemName(string name)
    {
        foreach (var cell in cells)
        {
            if (!cell.IsEmpty)
            {
                CellItem cellItem = cell.gameObject.GetComponentInChildren<CellItem>();
                if (cellItem.Item.Name == name)
                {
                    return cell;
                }
            }
        }
        return null;
    }
    /// <summary>Установка значения счетчика у ячейки.</summary>
    public void SetCellCounterValue(Cell cell, string value)
    {
        cell.GetComponentInChildren<CellCounter>().gameObject.GetComponent<TMP_Text>().text = value;
    }
    /// <summary>Хендлер для эвента отражающего открытие инвентаря.</summary>
    public delegate void InventoryOpenedHandlerEvent(Item newItem);
    public event InventoryOpenedHandlerEvent InventoryOpenedHandler;
    /// <summary>Хендлер для эвента отражающего изменение количества айтема в инвентаре (пака).</summary>
    public delegate void ItemSelectedChangedHandler(Item newItem);
    public event ItemSelectedChangedHandler ItemSelectedChangedEvent;

}