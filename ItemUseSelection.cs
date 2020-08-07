using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using TMPro;

namespace PrototypeGame
{
    public class ItemUseSelection : UIButtonScript
    {
        List<Action> itemFunctions = new List<Action>(3);
        public dynamic item;
        public GameObject dropDownMenu;
        public GameObject currentSlot;

        public void Start()
        {
            itemFunctions.Add(UseItem);
            itemFunctions.Add(GiveItem);
            itemFunctions.Add(DropItem);
        }

        public void SelectUsage(int val)
        {
            itemFunctions[val]();        
        }

        public void UseItem()
        {            
            if (item != null)
            {
                item.Use();
                Debug.Log(currentSlot);
                dropDownMenu.SetActive(false);
                EventSystem.current.SetSelectedGameObject(currentSlot);
                currentSlot.GetComponent<InventorySlot>().item = null;
                currentSlot.GetComponent<InventorySlot>().empty = true;
            }
            else
                Debug.Log("No items in slot");
        }

        public void GiveItem()
        {
            //give item to another player
            if (item != null)
            {
                Debug.Log(item.itemName);
                dropDownMenu.SetActive(false);
                EventSystem.current.SetSelectedGameObject(currentSlot);
                currentSlot.GetComponent<InventorySlot>().item = null;
                currentSlot.GetComponent<InventorySlot>().empty = true;
            }
            else
                Debug.Log("No items in slot");
        }

        public void DropItem()
        {
            if (item != null)
            {
                Destroy(item);
                dropDownMenu.SetActive(false);
                EventSystem.current.SetSelectedGameObject(currentSlot);
                currentSlot.GetComponent<InventorySlot>().item = null;
                currentSlot.GetComponent<InventorySlot>().empty = true;
            }
            else
                Debug.Log("No items in slot");
        }
    }
}
