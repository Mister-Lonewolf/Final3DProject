using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class Inventory : MonoBehaviour
    {
        static string currentlyHolding = "";
        public GameObject inventoryText;

        Color color = Color.white;

        void Start()
        {
            inventoryText.GetComponent<Text>().text = "Holding: ";
        }
        private void Update()
        {
            inventoryText.GetComponent<Text>().text = "Holding: " + currentlyHolding;
            switch (currentlyHolding)
            {
                case "PMD":
                    color = Color.blue;
                    break;
                case "GFT":
                    color = Color.green;
                    break;
                case "Rest":
                    color = Color.red;
                    break;
                case "Paper":
                    color = Color.yellow;
                    break;
                default: 
                    color = Color.white; 
                    break;
            }
            inventoryText.GetComponent<Text>().color = color;
        }


        public static void SetInventory(string itemType)
        {
            currentlyHolding = itemType;
        }

        public static bool IsEmpty()
        {
            return currentlyHolding == "";
        }

        public static string GetInventory()
        {
            return currentlyHolding;
        }

        public static void RemoveInventory()
        {
            currentlyHolding = "";
        }
    }
}