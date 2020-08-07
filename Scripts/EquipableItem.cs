using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeGame
{
    [CreateAssetMenu(menuName = "Items/Equipable Item")]
    public class EquipableItem : Items
    {
        public bool isUnarmed;
        public bool equipped;
        public string slotType;
        EquipmentSlotManager equipmentSlotManager;

        private void Initialize()
        {
            equipmentSlotManager = PlayerManager.instance.GetComponentInChildren<EquipmentSlotManager>();
        }

        public override void Use()
        {
            Initialize();
            equipmentSlotManager.LoadEquipmentOnSlot(this, slotType);
            equipmentSlotManager.LoadEquipementOnEquipMenu(this, slotType);
        }
    }
}

