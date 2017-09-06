using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Inventory : MonoBehaviour {

    private List<Item> itemList;
    public List<Item> inventory;


	// Use this for initialization
	void Start () {
        itemList = new List<Item>()
        {
            new Item() {
                itemName = "Visitor Pass",
                itemID = 0,
                itemDesc = "A visitor pass... that was left for you... wat."
           }
        };
        inventory = new List<Item>();
    }
	
	// Update is called once per frame
	public void addtoInventory (string item) {
		if (CheckInventory(item) == false)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].itemName == item)
                {
                    inventory.Add(itemList[i]);
                }
            }
        }
	}

    public bool CheckInventory (string item)
    {
        bool inInventory;
        inInventory = false;

        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == item)
            {
                inInventory = true;
            }
        }
        if (inInventory)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public class Item
    {
        public string itemName;
        public int itemID;
        public string itemDesc;
    }
}
