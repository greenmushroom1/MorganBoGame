using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeGame
{
    public class TestInventoryItemScript : MonoBehaviour
    {
        public InventoryHandler inventoryHandler;
        public EquipableItem item;
        public EquipableItem item1;

        // Start is called before the first frame update
        void Start()
        {
            inventoryHandler.AddItem(item);
            inventoryHandler.AddItem(item1);
        }
    }
}

