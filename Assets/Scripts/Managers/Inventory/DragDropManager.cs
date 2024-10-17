using TMPro;

/// <summary>����� ����������� ������ ����������� ������ ���������.</summary>
public static class DragDropManager
{
    /// <summary>������� ������ ���������.</summary>
    public static Cell CurrentCell = null;

    /// <summary>����� ��� ����� ���� ����� ���������.</summary>
    /// <param name="cell1"> ������ ������.</param>
    /// <param name="cell2"> ������ � ������� ����� �������� ������.</param>
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