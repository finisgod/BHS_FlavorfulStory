namespace FlavorfulStory.UI.Dragging
{
    /// <summary> Классы, реализующие этот интерфейс, могут выступать 
    /// в качестве источника для перетаскивания "DragItem".</summary>
    /// <typeparam name="T"> Тип, представляющий перетаскиваемый элемент.</typeparam>
    public interface IDragSource<T> where T : class
    {
        /// <summary> Получить тип элемента, который в данный момент находится в этом источнике.</summary>
        public T GetItem();

        /// <summary> Получить количество элементов в этом источнике.</summary>
        public int GetNumber();

        /// <summary> Удалить заданное количество элементов из источника.</summary>
        /// <param name="number"> Это значение никогда не должно превышать число, 
        /// возвращаемое с помощью "GetNumber".</param>
        public void RemoveItems(int number);
    }
}