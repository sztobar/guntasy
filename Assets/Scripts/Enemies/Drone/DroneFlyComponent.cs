using Kite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drone
{
    public class DroneFlyComponent : MonoBehaviour
    {

        [SerializeField]
        private float timeToFullSpeed = .3f;

        [SerializeField]
        private float timeToStop = .1f;

        [SerializeField]
        private float movementTileSpeed = 5f;

        [SerializeField]
        private ParticleSystem walkParticles;

        #region dependencies
        private DronePhysicsComponent physics;
        private HorizontalFlipComponent direction;
        #endregion
        private float smoothDampAccelerateVelocity;
        private float smoothDampDecelerateVelocity;
        public float MovementSpeed => movementTileSpeed * TileHelpers.TILE_SIZE;

        public void DroneAwake(DroneGameplayController controller)
        {
            physics = controller.Physics;
        }

        protected void DroneFixedUpdateImpl()
        {
            float moveInputX = 1f;
            float velocityX = GetVelocityX(moveInputX);
            physics.SetVelocityX(velocityX);
            
            MoveInputEffects(moveInputX);
        }

        private float GetVelocityX(float moveInputX)
        {
            if (moveInputX != 0)
            {
                return GetMovingVelocityX(moveInputX);
            }
            else
            {
                return GetStoppedVelocityX(moveInputX);
            }
        }

        private float GetMovingVelocityX(float moveInputX)
        {
            smoothDampDecelerateVelocity = 0f;
            float targetVelocity = moveInputX * MovementSpeed;
            float velocityX = Mathf.SmoothDamp(physics.Velocity.x, targetVelocity, ref smoothDampAccelerateVelocity, timeToFullSpeed);
            return velocityX;
        }

        private float GetStoppedVelocityX(float moveInputX)
        {
            smoothDampAccelerateVelocity = 0f;
            float velocityX = Mathf.SmoothDamp(physics.Velocity.x, 0f, ref smoothDampDecelerateVelocity, timeToStop);
            return velocityX;
        }

        private void MoveInputEffects(float moveInputX)
        {
            /*if (moveInputX != 0)
            {
                direction.Direction = Direction2Extensions.FromFloat(moveInputX);

                if (ground.IsGrounded)
                {
                    animator.PlayWalk();

                    if (walkParticles && !walkParticles.isPlaying)
                    {
                        walkParticles.Play();
                    }
                }
                else
                {
                    if (walkParticles && walkParticles.isPlaying)
                    {
                        walkParticles.Stop();
                    }
                }
            }
            else
            {
                if (ground.IsGrounded)
                {
                    animator.PlayIdle();
                }
                if (walkParticles && walkParticles.isPlaying)
                {
                    walkParticles.Stop();
                }
            }*/
        }
    }
}