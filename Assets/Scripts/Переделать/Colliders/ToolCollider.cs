using System.Collections.Generic;
using UnityEngine;

public class ToolCollider : BaseCollider //NotUsed yet //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    private ToolColliderGameObjectCollection m_ToolColliderGameObjectCollection = new ToolColliderGameObjectCollection(); //��� �� ������
    /// <summary>����� ������������ ��� ����� � ��������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerEnter(Collider other)
    {
        m_ToolColliderGameObjectCollection.Append(other.gameObject);
    }
    /// <summary>����� ������������ ��� ������ �� ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerExit(Collider other)
    {
        m_ToolColliderGameObjectCollection.Remove(other.gameObject);
    }

    public ToolColliderGameObjectCollection GetObjectCollection()
    {
        return m_ToolColliderGameObjectCollection;
    }
 
    //private void Update()
    //{
        //List<AgricultureObject> agricultures = GetObjectCollection().GetItems<AgricultureObject>();
        //UnityEngine.//Debug.Log("Founded: " + agricultures.Count + "Agricutures");
    //}
}

public class ToolColliderGameObjectCollection
{
    protected List<GameObject> ToolColliderGameObjectArray = new List<GameObject>();
    public List<T> GetItems<T>() 
    {
        List<T> list = new List<T>();
        foreach (var item in ToolColliderGameObjectArray)
        {
            T targetItem = default(T);
            bool getStatus = item.TryGetComponent<T>(out targetItem);
            if (getStatus)
            {
                list.Add(targetItem);
            }
        }
        return list;
    }
    public void Append(GameObject newObject)
    {
        ToolColliderGameObjectArray.Add(newObject);
    }
    public void Remove(GameObject deletedObject)
    {
        ToolColliderGameObjectArray.Remove(deletedObject);
    }
}