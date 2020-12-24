using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drone
{
    public class DroneGameplayController : MonoBehaviour
    {

        #region Components
        [Header("Components")]
        [SerializeField] GameObject leftGunSlot;
        [SerializeField] GameObject rightGunSlot;
        [SerializeField] GameObject playerDetector;
        [SerializeField] DroneFlyComponent droneFlyComponent;
        [SerializeField] DroneBehaviourComponent droneBehaviourComponent;
        #endregion

        #region Dependencies
        [Header("Dependencies")]
        [SerializeField] DronePhysicsComponent physics;
        #endregion

        #region Getters
        public DronePhysicsComponent Physics => physics;
        #endregion

        private void Awake()
        {
            Debug.Log("BEAST HAS AWOKEN!");
            droneFlyComponent.DroneAwake(this);
      }
    }
}