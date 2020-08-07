using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PrototypeGame
{
    public class AnimationHandler : MonoBehaviour
    {
        public PlayerManager playerManager;
        public InputHandler inputHandler;
        public Animator animator;
        public PlayerMovement playerMovement;
        string currentAnimationState;

        public void Initialize()
        {
            playerManager = PlayerManager.instance;
            animator = GetComponent<Animator>();
            inputHandler = GetComponent<InputHandler>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        public void CheckAnimationState()
        {
            if (currentAnimationState == null)
                currentAnimationState = playerManager.animationBaseState;

            animator.SetBool(currentAnimationState, false);
            animator.SetBool(playerManager.animationBaseState, true);
        }

        public void UpdateAnimatorValues(float delta)
        {
            float moveAmount = Mathf.Sqrt(Mathf.Pow(inputHandler.MoveX, 2) + Mathf.Pow(inputHandler.MoveY, 2));
            if (moveAmount > 0)
                animator.SetBool("Moving", true);
            else
                animator.SetBool("Moving", false);

            if (moveAmount > .2 && moveAmount < .5f)
                animator.SetFloat("MovementThreshold", .25f, .5f, delta);
            else if (moveAmount >= .5f && moveAmount < 1f)
                animator.SetFloat("MovementThreshold", .55f, .5f, delta);
            else if (moveAmount >= 1f)
                animator.SetFloat("MovementThreshold", 1.2f, .5f, delta);
            else
                animator.SetFloat("MovementThreshold", 0f,.2f, delta);
        }

        public void PlayTargetAnimation(string targetAnimation, bool isRoot=false)
        {
            animator.applyRootMotion = isRoot;
            animator.CrossFade(targetAnimation, .1f);
        }

        private void OnAnimatorMove()
        {
            float delta = Time.deltaTime;

            if (PlayerManager.instance.playerState!="inMenu")
            {
                playerMovement.characterRigidbody.drag = 0;
                Vector3 deltaPosition = animator.deltaPosition;
                deltaPosition.y = 0;
                Vector3 velocity = deltaPosition / delta;
                playerMovement.characterRigidbody.velocity = velocity * 1.5f;
            }
        }
    }
}


