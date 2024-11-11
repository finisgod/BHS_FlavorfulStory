using TMPro;

/// <summary>Класс описывающий логику перемещения иконок инвентаря.</summary>
public static class DragDropManager
{
    /// <summary>Текущая ячейка инвентаря.</summary>
    public static Cell CurrentCell = null;

    /// <summary>Метод для свапа двух ячеек инвентаря.</summary>
    /// <param name="cell1"> Взятая ячейка.</param>
    /// <param name="cell2"> Ячейка с которой нужно поменять взятую.</param>
    public static void SwapCellCountersValues(Cell cell1, Cell cell2)
    {
        TMP_Text cell1Text = cell1.GetComponentInChildren<CellCounter>().gameObject.GetComponent<TMP_Text>();
        TMP_Text cell2Text = cell2.GetComponentInChildren<CellCounter>().gameObject.GetComponent<TMP_Text>();
        string temp = cell1Text.text;
        cell1Text.text = cell2Text.text;
        cell2Text.text = temp;

        cell1.IsEmpty = cell1Text.text == "0";
        cell2.IsEmpty = cell2Text.text == "0";
        CellMovedEvent?.Invoke();
    }

    public delegate void CellMovedEventHandler();
    public static event CellMovedEventHandler CellMovedEvent;
}