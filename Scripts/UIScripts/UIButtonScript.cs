using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PrototypeGame
{
    public class UIButtonScript : MonoBehaviour
    {
        public void GamepadClick(GameObject buttonObject)
        {
            if (PlayerManager.instance.inputHandler.gamepadSouthInput)
            {
                Button button = buttonObject.GetComponent<Button>();
                button.onClick.Invoke();
                PlayerManager.instance.inputHandler.gamepadSouthInput = false;
            }
        }

        public void FixedUpdate()
        {
            if (PlayerManager.instance.playerState == "inMenu")
                GamepadClick(EventSystem.current.currentSelectedGameObject);
        }
    }
}
