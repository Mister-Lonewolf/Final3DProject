using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class GetInventory : MonoBehaviour
{
    public Text inventoryText;
    public GameObject player;
    private Color color = Color.white;

    private void Start()
    {
        inventoryText.text = "Holding: ";
    }
    private void Update()
    {
        switch (player.GetComponent<Inventory>().GetInventory())
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
        inventoryText.GetComponent<Text>().text = "Holding: " + player.GetComponent<Inventory>().GetInventory();
        inventoryText.GetComponent<Text>().color = color;
    }
}
