using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeGame
{
    public class EquipmentHolderSlot : MonoBehaviour
    {
        public Transform parentOverride;
        public GameObject currentModel;
        public string slotType;

        public void UnloadEquipment()
        {
            if (currentModel != null)
                currentModel.SetActive(false);
        }

        public void UnloadEquipmentAndDestroy()
        {
            if (currentModel != null)
                Destroy(currentModel);
        }

        public void LoadEquipmentModel(dynamic item)
        {
            if (item == null)
                return;

            GameObject equipmentModel = Instantiate(item.modelPrefab) as GameObject;
            if (equipmentModel != null)
            {
                if (parentOverride!=null)
                    equipmentModel.transform.parent = parentOverride;
                else
                    equipmentModel.transform.parent = transform;

                equipmentModel.transform.localPosition = Vector3.zero;
                equipmentModel.transform.localRotation = Quaternion.identity;
                equipmentModel.transform.localScale = Vector3.one;
            }
            currentModel = equipmentModel;
        }
    }
}
