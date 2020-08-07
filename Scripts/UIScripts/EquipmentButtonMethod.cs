using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace PrototypeGame
{
    public class EquipmentButtonMethod : UIButtonScript
    {
        public GameObject equipmentMenu, inventoryMenu;
        public GameObject equipmentTabButton, inventoryTabButton;

        public void Start()
        {
            equipmentMenu.SetActive(false);
        }

        public void SwithToEquipmentTab()
        {
            inventoryMenu.SetActive(false);
            equipmentMenu.SetActive(true);

            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            // set new selected object
            EventSystem.current.SetSelectedGameObject(inventoryTabButton);
        }
    }
}

