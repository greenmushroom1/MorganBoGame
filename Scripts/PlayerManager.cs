using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeGame
{
    public class PlayerManager : MonoBehaviour
    {
        public InputHandler inputHandler;
        public PlayerMovement playerMovement;
        public static PlayerManager instance=null;
        public Transform playerTransform;
        public CameraHandler cameraHandler;
        public string animationBaseState="SwordAndShield";
        public string playerState="ready";
        public InventoryHandler inventoryHandler;

        // Start is called before the first frame update
        private void Awake()
        {
            if (instance == null)
                instance = this;
            playerTransform = GetComponent<Transform>();
            inputHandler = GetComponent<InputHandler>();
            inventoryHandler = GetComponent<InventoryHandler>();
        }

        private void Start()
        {
            cameraHandler = CameraHandler.instance;           
        }

        private void FixedUpdate()
        {
            playerMovement.HandleFalling();
        }

        // Update is called once per frame
        void Update()
        {
            float delta = Time.deltaTime;
            inputHandler.TickInput(delta);

            inventoryHandler.ActivateInventoryUI();
            if (playerState == "ready")
            {
                playerMovement.ExcuteMovement(delta);
                playerMovement.HandleBlock();
                playerMovement.HandleAttack();
            }

            if (playerState != "inMenu")
                cameraHandler.HandleCamera(delta);
            else
                playerMovement.characterRigidbody.velocity = Vector3.zero;
        }
    }
}

