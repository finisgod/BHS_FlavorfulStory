/// <summary> �����, ����������� ������������� �������.</summary>
public class UsableObject : Object
{
    public UsableObject(string name) : base(name) { }
    /// <summary> ����� ��� �������������� � ��������.</summary>
    public virtual void Use() { }
}