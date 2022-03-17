using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public GameObject inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            inventoryUI.SetActive(true);
        }
        if (Input.GetKeyDown("b"))
        {
            inventoryUI.SetActive(false);
        }
    }

    void UpdateUI()
    {

    }
}
