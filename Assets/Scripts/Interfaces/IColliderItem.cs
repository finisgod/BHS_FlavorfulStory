public interface IColliderItem<T> where T : BaseCollider
{
    public T ItemCollider { get; }
}