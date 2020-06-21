using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();

    void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item=> item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(0, "Iron", "Rusty Iron Sword",
            new Dictionary<string, int> {
                 { "BaseDamage", 10 },
                { "SpecialDamage", 20 }
            }),
            new Item(1, "Iron", "A shinny Iron Sword.",
            new Dictionary<string, int> {
                { "BaseDamage", 15 },
                { "SpecialDamage", 25 }
            }),
            new Item(2, "Gold", "A gold sword.",
            new Dictionary<string, int> {
                { "BaseDamage", 17 },
                { "SpecialDamage", 27 }
            }),
            new Item(3, "Gold", "Cleaver",
            new Dictionary<string, int> {
                 { "BaseDamage", 5 },
                { "SpecialDamage", 50 }
            }),
            new Item(4, "Diamond", "A pretty diamond.",
            new Dictionary<string, int> {
                { "BaseDamage", 17 },
                { "SpecialDamage", 27 }
            }),
            new Item(5, "Diamond", "Excalibur",
            new Dictionary<string, int> {
                { "BaseDamage", 50 },
                { "SpecialDamage", 75 }
            })
        };
    }
}
