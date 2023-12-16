using UnityEngine;

namespace Assets.Scripts
{
    public class Inventory : MonoBehaviour
    {
        private string currentlyHolding = "";

        public void SetInventory(string itemType)
        {
            currentlyHolding = itemType;
        }

        public bool IsEmpty()
        {
            return currentlyHolding == "";
        }

        public string GetInventory()
        {
            return currentlyHolding;
        }

        public void RemoveInventory()
        {
            currentlyHolding = "";
        }
    }
}