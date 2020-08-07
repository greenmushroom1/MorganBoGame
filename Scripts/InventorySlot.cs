using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace PrototypeGame
{
    public class InventorySlot : UIButtonScript
    {
        public bool empty;
        public dynamic item;
        public Transform slotIconPanel;
        public GameObject itemUseDropDown;
        public RectTransform rectTransform;
        public RectTransform dropDownTransform;

        private void Awake()
        {
            slotIconPanel = transform.GetChild(0);

            itemUseDropDown.SetActive(false);
            rectTransform = gameObject.GetComponent<RectTransform>();
        }

        public void UpdateSlot()
        {         
            slotIconPanel.GetComponent<Image>().sprite = item.itemIcon;
        }

        public void ItemUIPopup()
        {
            itemUseDropDown.SetActive(true);
            GameObject button = itemUseDropDown.GetComponentsInChildren<Button>()[0].gameObject;
            EventSystem.current.SetSelectedGameObject(button);
            button.GetComponent<ItemUseSelection>().item = item;
            button.GetComponent<ItemUseSelection>().currentSlot = this.transform.gameObject;

            dropDownTransform = itemUseDropDown.GetComponent<RectTransform>();
            dropDownTransform.anchoredPosition = rectTransform.anchoredPosition + Vector2.right*200;
        }
    }
}

