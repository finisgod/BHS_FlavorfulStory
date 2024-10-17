/// <summary> Класс, описывающий интерактивные объекты.</summary>
public class UsableObject : Object
{
    public UsableObject(string name) : base(name) { }
    /// <summary> Метод для взаимодействия с объектом.</summary>
    public virtual void Use() { }
}