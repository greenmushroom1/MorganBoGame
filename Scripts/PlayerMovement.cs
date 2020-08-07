using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeGame
{
    public class PlayerMovement : MonoBehaviour
    {
        public float movementSpeed=5f;
        public float rotationSpeed=10f;

        public Rigidbody characterRigidbody;
        public Transform characterTransform;
        public InputHandler inputHandler;

        public Transform cameraTransfrom;
        public AnimationHandler animationHandler;
        public float fallSpeed = 250;

        private float characterCenterHeight;
        public bool grounded;
        LayerMask groundCheckLayerMask;

        public CapsuleCollider capsuleCollider;

        Vector3 moveDirection;
        Vector3 normalVector = Vector3.up;

        private void Start()
        {
            characterTransform = GetComponent<Transform>();
            characterRigidbody = GetComponent<Rigidbody>();
            inputHandler = GetComponent<InputHandler>();
            cameraTransfrom = Camera.main.transform;
            animationHandler = GetComponent<AnimationHandler>();
            capsuleCollider = GetComponent<CapsuleCollider>();
            groundCheckLayerMask = ~(1 << 9| 1 << 1 | 1 << 2 | 1 << 5);
        }

        public void ExcuteMovement(float delta)
        {
            moveDirection = Vector3.zero;
            moveDirection = cameraTransfrom.forward * inputHandler.MoveY+ cameraTransfrom.right * inputHandler.MoveX;
            moveDirection.y = 0;
            moveDirection.Normalize();

            HandleRotation(delta, moveDirection);

            //Vector3 planarDirection = Vector3.ProjectOnPlane(moveDirection, normalVector);
            //characterRigidbody.velocity = planarDirection * movementSpeed;

            animationHandler.CheckAnimationState();
            animationHandler.UpdateAnimatorValues(delta);
        }

        public void HandleBlock()
        {
            if (inputHandler.leftTriggerInput)
            {
                animationHandler.animator.SetBool("Block", true);
                animationHandler.PlayTargetAnimation("HoldBlock");
            }
            else
                animationHandler.animator.SetBool("Block", false);
        }

        public void HandleAttack()
        {
            if (inputHandler.rightTriggerInput)
            {
                animationHandler.animator.SetBool("Attack", true);
                animationHandler.PlayTargetAnimation("SwordAndShieldSlash");
            }                
            else
                animationHandler.animator.SetBool("Attack", false);
        }

        public void HandleRotation(float delta, Vector3 moveDirection)
        {
            if (moveDirection == Vector3.zero)
                moveDirection = characterTransform.forward;
                
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            characterTransform.rotation = Quaternion.Slerp(characterTransform.rotation, targetRotation, rotationSpeed * delta);
        }

        public void HandleFalling()
        {
            characterCenterHeight = capsuleCollider.bounds.extents.y;

            RaycastHit ground_check;

            Vector3 cast_origin = characterTransform.position + Vector3.up * 10f;
            float cast_distance = 9.9f;

            if (PlayerManager.instance.playerState == "falling")
                grounded = false;
            else
            {
                grounded = Physics.SphereCast(cast_origin, .2f, Vector3.down, out ground_check, cast_distance, groundCheckLayerMask);
            }

            if (!grounded)
            {
                characterRigidbody.AddForce(Vector3.down*fallSpeed);

                RaycastHit ground_distance;
                if (Physics.Raycast(characterTransform.position,Vector3.down,out ground_distance))
                {
                    if (ground_distance.distance <= 0.1f)
                        animationHandler.animator.SetBool("Falling", false);
                    else if (ground_distance.distance > 2f)
                        animationHandler.PlayTargetAnimation("Falling");
                        animationHandler.animator.SetFloat("FallThreshold", ground_distance.distance);
                }
            }
        }
    }
}


