using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Drone
{
    public class DroneBehaviourComponent : MonoBehaviour
    {
        [SerializeField]
        private float PatrolXStart = 0;

        [SerializeField]
        private float PatrolXEnd = 0;

        [SerializeField]
        private bool PlayerDetected = false;

        [SerializeField]
        private int Direction = 1;

        [SerializeField]
        private float speed = 10f;

        private float initialY = 0f;
        private float floatYOffset = 3f;
        private float yDirection = 1;
        private DronePhysicsComponent physics;

        [SerializeField]
        private float floatSpeed = 5;

        [SerializeField]
        private GameObject LeftGun = null;
        [SerializeField]
        private GameObject RightGun = null;

        [SerializeField]
        private GameObject LeftGunSlot = null;
        [SerializeField]
        private GameObject RightGunSlot = null;

        [SerializeField]
        private float gunsAngle = 30f;

        [SerializeField]
        private GameObject Target = null;

        [SerializeField]
        private CircleCollider2D PlayerDetector = null;

        [SerializeField] private BoxCollider2D droneCollider;

        private static readonly RaycastHit2D[] results = new RaycastHit2D[1];
        private float smoothDampDecelerateVelocity = 0f;
        private float smoothDampFloatVelocity = 0f;

        public void DroneAwake(DroneGameplayController controller)
        {
            this.physics = controller.Physics;
        }

        // Start is called before the first frame update
        void Start()
        {
            this.initialY = this.transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            if (!this.PlayerDetected)
            {
                this.DoPatrol();
            } else {
                this.LockTarget();
                this.DoPursuit();
            }
            this.DoFloatyFloat();
        }

        void DoPatrol()
        {
            if (this.Direction == 1 && this.transform.position.x >= this.PatrolXEnd)
            {
                this.DoAFlip(-1);
            }
            else if (this.Direction == -1 && this.transform.position.x <= this.PatrolXStart)
            {
                this.DoAFlip(1);
            }

            float targetX = this.PatrolXStart;
            if(this.Direction == 1)
            {
                targetX = this.PatrolXEnd;
            }
            float newVelocity = this.calculateLerpVelocity(this.transform.position.x, targetX, 45f, this.Direction);
            this.physics.SetVelocityX(newVelocity);
        }

        void DoAFlip(int newDirection)
        {
            this.Direction = newDirection;
            if (newDirection > 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                this.LeftGunSlot.transform.position = this.LeftGunSlot.transform.position + new Vector3(0f, 0f, 4f);
                this.RightGunSlot.transform.position = this.RightGunSlot.transform.position + new Vector3(0f, 0f, -4f);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = true;

                this.LeftGunSlot.transform.position = this.LeftGunSlot.transform.position + new Vector3(0f, 0f, -4f);
                this.RightGunSlot.transform.position = this.RightGunSlot.transform.position + new Vector3(0f, 0f, 4f);
            }
        }

        void LockTarget()
        {
            Vector2 targetPosition = this.Target.transform.position;
            Vector2 myPosition = this.transform.position;
            Vector2 aim = targetPosition - myPosition;

            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, aim);

            this.LeftGunSlot.transform.rotation = rotation;
            this.RightGunSlot.transform.rotation = rotation;
        }

        void DoFloatyFloat()
        {
            if (this.transform.position.y - this.initialY >= this.floatYOffset && this.yDirection == 1)
            {
                this.yDirection = -1;
            }
            else if (this.transform.position.y - this.initialY <= -this.floatYOffset && this.yDirection == -1)
            {
                this.yDirection = 1;
            }
            float velocityY = Mathf.SmoothDamp(this.physics.Velocity.y, this.floatSpeed * yDirection, ref smoothDampFloatVelocity, 0.3f);
            this.physics.SetVelocityY(velocityY);
        }

        void DoPursuit()
        {
            if (this.Target.transform.position.x > this.transform.position.x && this.Direction == -1)
            {
                this.DoAFlip(1);
            }
            else if (this.Target.transform.position.x < this.transform.position.x && this.Direction == 1)
            {
                this.DoAFlip(-1);
            }
            float targetDistance = Mathf.Abs(this.Target.transform.position.x - this.transform.position.x);
            if (targetDistance > 100f)
            {
                float direction = -1;
                float yDirection = -1;
                float dT = Time.deltaTime;

                if (this.Target.transform.position.x > this.transform.position.x)
                {
                    direction = 1;
                }

                if (this.Target.transform.position.y > this.transform.position.y)
                {
                    yDirection = 1;
                }


                float velocityRatio = Mathf.Abs(this.Target.transform.position.x - this.transform.position.x) / 100f;
                if(velocityRatio > 1f)
                {
                    velocityRatio = 1f;
                }

                float newVelocity = Mathf.Lerp(1f, 45f, velocityRatio);

                newVelocity = newVelocity * direction * dT;

                float flipBoost = 0f;
                if (this.physics.Velocity.x > 0 && newVelocity < 0)
                {
                    flipBoost = (this.physics.Velocity.x / 100) * 1;
                    newVelocity = newVelocity - flipBoost;
                } else if(this.physics.Velocity.x < 0 && newVelocity > 0)
                {
                    flipBoost = (this.physics.Velocity.x / 100) * 1;
                    newVelocity = newVelocity + Mathf.Abs(flipBoost);
                }

                this.physics.SetVelocityX(this.physics.Velocity.x + newVelocity);
                this.physics.SetVelocityY(this.physics.Velocity.y + (newVelocity/2 * yDirection * dT));
            } else if(targetDistance <= 50f)
            {
                float velocityX = Mathf.SmoothDamp(this.physics.Velocity.x, 0f, ref smoothDampDecelerateVelocity, 0.3f);
                this.physics.SetVelocityX(velocityX);
            }
        }

        private float calculateLerpVelocity(float sourceX, float targetX, float maxSpeed, float direction, float minSpeed = 1f, float scale = 100f)
        {
            float velocityRatio = Mathf.Abs(targetX - sourceX) / scale;
            if (velocityRatio > 1f)
            {
                velocityRatio = 1f;
            }

            float newVelocity = Mathf.Lerp(minSpeed, maxSpeed, velocityRatio);
            newVelocity = newVelocity * direction;
            return newVelocity;
        }

        private void FixedUpdate()
        {
            if(this.DetectsPlayer())
            {
                this.PlayerDetected = true;
                this.Target = results[0].transform.gameObject;
            }
        }

        private bool DetectsPlayer()
        {
            int count = PlayerDetector.Cast(Vector2.zero, results);
            return count > 0;
        }
    }

}