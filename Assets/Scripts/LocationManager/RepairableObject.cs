namespace FlavorfulStory.LocationManager
{
    public class RepairableObject : InteractableObject
    {
        protected override void Interact()
        {
            _appearanceSwitcher.ChangeAppearance();
        }
    }
}