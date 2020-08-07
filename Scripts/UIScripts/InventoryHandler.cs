using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace PrototypeGame
{
    public class InventoryHandler : MonoBehaviour
    {
        public bool inventoryUIEnabled=false;
        public InputHandler inputHandler;
        private int allSlots=35;
        private int enabledSlots;
        private InventorySlot[] slots;

        [Header("Required Objects")]
        public GameObject slotHolder;
        public GameObject inventoryMenu, equipmentTabButton, inventoryUI, itemUseDropDown,EquipedItems;

        public void Awake()
        {
            inventoryUI.SetActive(false);
            itemUseDropDown.SetActive(false);
            
            inputHandler = GetComponent<InputHandler>();
            slots = slotHolder.GetComponentsInChildren<InventorySlot>();

            foreach (InventorySlot slot in slots)
            {
                if (slot.item == null)
                    slot.empty = true;
            }
        }

        public void ActivateInventoryUI()
        {
            if (inputHandler.gamepadNorthInput && !inventoryUIEnabled)
            {
                inventoryUIEnabled = true;
                inventoryUI.SetActive(true);
                inputHandler.gamepadNorthInput = false;
                EventSystem.current.SetSelectedGameObject(equipmentTabButton);
                PlayerManager.instance.playerState = "inMenu";
                //Time.timeScale = 0f;
            }

            else if (inputHandler.gamepadNorthInput && inventoryUIEnabled)
            {
                inventoryUIEnabled = false;
                inventoryUI.SetActive(false);
                inputHandler.gamepadNorthInput = false;
                itemUseDropDown.SetActive(false);

                PlayerManager.instance.playerState = "ready";
                //Time.timeScale = 1f;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "item")
            {
                GameObject itemPickedUp = other.gameObject;
                Items item = itemPickedUp.GetComponent<Items>();

                AddItem(itemPickedUp);
            }
        }

        public void AddItem(dynamic item)
        {           
            for (int i = 0; i <allSlots; i++)
            {
                if(slots[i].empty)
                {
                    item.pickedUp = true;
                    slots[i].item = item;
                    
                    slots[i].UpdateSlot();
                    slots[i].empty = false;
                    //item.SetActive(false);
                    return;
                }
            }
        }
    }
}

