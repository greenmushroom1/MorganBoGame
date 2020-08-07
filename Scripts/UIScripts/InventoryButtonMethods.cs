using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace PrototypeGame
{
    public class InventoryButtonMethods : UIButtonScript
    {
        public GameObject equipmentMenu,inventoryMenu;
        public GameObject equipmentTabButton,inventoryTabButton;

        public void SwithToInventoryTab()
        {
            equipmentMenu.SetActive(false);
            inventoryMenu.SetActive(true);

            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            // set new selected object
            EventSystem.current.SetSelectedGameObject(equipmentTabButton);
        }        
    }
}

