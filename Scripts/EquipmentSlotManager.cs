using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeGame
{
    public class EquipmentSlotManager : MonoBehaviour
    {
        EquipmentHolderSlot leftHandSlot;
        EquipmentHolderSlot rightHandSlot;
        EquipmentHolderSlot helmetSlot;
        EquipmentHolderSlot leggingSlot;
        EquipmentHolderSlot torsoSlot;
        EquipmentHolderSlot gloveSlot;
        EquipmentHolderSlot bootSlot;
        EquipmentHolderSlot amuletSlot;

        InventorySlot EquipedAmulet;
        InventorySlot EquipedHelmet;
        InventorySlot EquipedRightHand;
        InventorySlot EquipedLeftHand;
        InventorySlot EquipedTorso;
        InventorySlot EquipedBoots;
        InventorySlot EquipedLegging;
        InventorySlot EquipedGloves;

        public InventoryHandler inventoryHandler;
        public List<EquipmentHolderSlot> equipmentHolderSlots;
        public List<InventorySlot> equipedItems;
        public GameObject EquipedItems;

        public void Awake()
        {
            inventoryHandler = GetComponent<InventoryHandler>();

            EquipmentHolderSlot[] equipmentHolderSlots = GetComponentsInChildren<EquipmentHolderSlot>();
            foreach (EquipmentHolderSlot equipmentHolderSlot in equipmentHolderSlots)
            {
                switch (equipmentHolderSlot.slotType)
                {
                    case "helmetSlot":
                        helmetSlot = equipmentHolderSlot;
                        break;
                    case "gloveSlot":
                        gloveSlot = equipmentHolderSlot;
                        break;
                    case "leggingSlot":
                        leggingSlot = equipmentHolderSlot;
                        break;
                    case "torsoSlot":
                        torsoSlot = equipmentHolderSlot;
                        break;
                    case "leftHandSlot":
                        leftHandSlot = equipmentHolderSlot;
                        break;
                    case "rightHandSlot":
                        rightHandSlot = equipmentHolderSlot;
                        break;
                    case "amuletSlot":
                        amuletSlot = equipmentHolderSlot;
                        break;
                    case "bootSlot":
                        bootSlot = equipmentHolderSlot;
                        break;
                }
            }

            InventorySlot[] equipedItems = EquipedItems.GetComponentsInChildren<InventorySlot>();
            foreach (InventorySlot equipedItem in equipedItems)
            {
                switch (equipedItem.name)
                {
                    case "Amulets":
                        EquipedAmulet = equipedItem;
                        break;
                    case "Gloves":
                        EquipedGloves = equipedItem;
                        break;
                    case "LeftHandEquip":
                        EquipedLeftHand = equipedItem;
                        break;
                    case "RightHandEquip":
                        EquipedRightHand = equipedItem;
                        break;
                    case "Leggings":
                        EquipedLegging = equipedItem;
                        break;
                    case "Boots":
                        EquipedBoots = equipedItem;
                        break;
                    case "Helmets":
                        EquipedHelmet = equipedItem;
                        break;
                    case "Torso":
                        EquipedTorso = equipedItem;
                        break;
                }
            }
        }

        public void LoadEquipementOnEquipMenu(EquipableItem item, string slotType)
        {
            switch (slotType)
            {
                case "helmetSlot":
                    EquipedHelmet.item = item;
                    break;
                case "amuletSlot":
                    EquipedAmulet.item = item;
                    break;
                case "leggingSlot":
                    EquipedLegging.item = item;
                    break;
                case "gloveSlot":
                    EquipedGloves.item = item;
                    break;
                case "bootSlot":
                    EquipedBoots.item = item;
                    break;
                case "torsoSlot":
                    EquipedTorso.item = item;
                    break;
                case "leftHandSlot":
                    EquipedLeftHand.item = item;
                    break;
                case "rightHandSlot":
                    EquipedRightHand.item = item;
                    break;
            }
        }

        public void LoadEquipmentOnSlot(EquipableItem item, string slotType)
        {
            switch(slotType)
            {
                case "helmetSlot":
                    if (helmetSlot.currentModel != null)
                        helmetSlot.UnloadEquipment();
                    helmetSlot.LoadEquipmentModel(item);
                    break;
                case "amuletSlot":
                    if (amuletSlot.currentModel != null)
                        amuletSlot.UnloadEquipment();
                    amuletSlot.LoadEquipmentModel(item);
                    break;
                case "leggingSlot":
                    if (leggingSlot.currentModel != null)
                        leggingSlot.UnloadEquipment();
                    leggingSlot.LoadEquipmentModel(item);
                    break;
                case "gloveSlot":
                    if (gloveSlot.currentModel != null)
                        gloveSlot.UnloadEquipment();
                    gloveSlot.LoadEquipmentModel(item);
                    break;
                case "bootSlot":
                    if (bootSlot.currentModel != null)
                        bootSlot.UnloadEquipment();
                    bootSlot.LoadEquipmentModel(item);
                    break;
                case "torsoSlot":
                    if (torsoSlot.currentModel != null)
                        torsoSlot.UnloadEquipment();
                    torsoSlot.LoadEquipmentModel(item);
                    break;
                case "leftHandSlot":
                    if (leftHandSlot.currentModel != null)
                        leftHandSlot.UnloadEquipment();
                    leftHandSlot.LoadEquipmentModel(item);
                    break;
                case "rightHandSlot":
                    if (rightHandSlot.currentModel != null)
                        rightHandSlot.UnloadEquipment();
                    rightHandSlot.LoadEquipmentModel(item);
                    break;
            }
        }
    }
}

