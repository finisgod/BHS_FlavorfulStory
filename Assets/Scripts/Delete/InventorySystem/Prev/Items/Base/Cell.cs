using UnityEngine;
using UnityEngine.EventSystems;

/// <summary> Ѕазовый класс €чейки (дл€ хранени€ в инвентаре).</summary>
public class Cell : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] CanvasGroup canvasGroup;
    public int row = 0;
    public int col = 0;
    private bool _isEmpty = true;
    public bool IsEmpty { get { return _isEmpty; } set { _isEmpty = value; } }
    public static void OnCellClicked()
    {
        //Debug.Log("Cell clicked");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        DragDropManager.CurrentCell = this;
        //if (IsEmpty)
        //Debug.Log("Entered empty cell");
        //else
        //Debug.Log("Entered filled cell");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        DragDropManager.CurrentCell = null;
        //Debug.Log("Exit inventory");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        //Debug.Log("Cell OnBeginDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Cell OnDrag");
        CellItem item = this.gameObject.GetComponentInChildren<CellItem>();
        if (item != null)
        {
            item.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        CellItem item = this.gameObject.GetComponentInChildren<CellItem>();
        if (item != null)
        {
            //Debug.Log("Cell OnEndDrag");
            if (DragDropManager.CurrentCell != null)
            {
                if (DragDropManager.CurrentCell.IsEmpty)
                {
                    item.transform.SetParent(DragDropManager.CurrentCell.transform);
                    item.transform.SetAsFirstSibling();
                    DragDropManager.SwapCellCountersValues(DragDropManager.CurrentCell, this);
                }
            }
            item.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }

}