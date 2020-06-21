using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour {
    public List<UIItem> uiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public Sprite Slot1;

    void Awake()
    {
        for(int i = 0; i < 24; i++)
        {
            if (i == 0)
            {
                GameObject instance = Instantiate(slotPrefab);
                instance.transform.SetParent(slotPanel);
                uiItems.Add(instance.GetComponentInChildren<UIItem>());
                instance.name = "Slot1";
                instance.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                instance.GetComponent<UnityEngine.UI.Image>().sprite = Slot1;
                instance.GetComponent<UnityEngine.UI.Image>().type = UnityEngine.UI.Image.Type.Sliced;
            }
            else
            {
                GameObject instance = Instantiate(slotPrefab);
                instance.transform.SetParent(slotPanel);
                uiItems.Add(instance.GetComponentInChildren<UIItem>());
            }
        }
    }

    public void UpdateSlot(int slot, Item item)
    {
        uiItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i=> i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i=> i.item == item), null);
    }
}
