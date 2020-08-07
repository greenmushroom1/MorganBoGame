using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeGame
{
    public class InputHandler : MonoBehaviour
    {
        public float MouseX, MouseY,MoveX,MoveY;
        PlayerControls inputActions;
        public bool rightTriggerInput;
        public bool leftTriggerInput;
        public bool gamepadNorthInput;
        public bool gamepadSouthInput;

        Vector2 movementInput, cameraInput;
        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.MovementControls.performed += i => movementInput = i.ReadValue<Vector2>();
                inputActions.PlayerMovement.CameraControls.performed += j => cameraInput = j.ReadValue<Vector2>();
                inputActions.PlayerActions.Block.started += _ => leftTriggerInput = true;
                inputActions.PlayerActions.Block.canceled += _ => leftTriggerInput = false;
                inputActions.PlayerActions.Attack.started += _ => rightTriggerInput = true;
                inputActions.PlayerActions.Attack.canceled += _ => rightTriggerInput = false;
                inputActions.Menu.Inventory.canceled += _ => gamepadNorthInput=true;
                inputActions.Menu.Click.started += _ => gamepadSouthInput = true;
            }
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        //this is to make sure the inputs all have the same delta
        public void TickInput(float delta)
        {
            GetMoveInputs(delta);
        }

        public void GetMoveInputs(float delta)
        {
            MouseX = cameraInput.x;
            MouseY = cameraInput.y;
            MoveX = movementInput.x;
            MoveY = movementInput.y;
        }
    }
}

