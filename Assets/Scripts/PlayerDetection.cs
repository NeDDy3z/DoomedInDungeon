using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects the presence of the player within a specified radius and line of sight.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for detecting the player.
    /// </summary>
    public class PlayerDetection : MonoBehaviour
    {
        /// <summary>
        /// Gets a value indicating whether the player is currently visible.
        /// </summary>
        public bool playerVisible { get; private set; }

        /// <summary>
        /// The layer mask used to identify the target (player).
        /// </summary>
        public LayerMask targetLayer;

        /// <summary>
        /// The layer mask used to identify obstructions between the detector and the player.
        /// </summary>
        public LayerMask obstructionLayer;

        /// <summary>
        /// The radius within which the player can be detected.
        /// </summary>
        public float radius = 2.5f;

        /// <summary>
        /// Determines whether to show the detection radius in the editor.
        /// </summary>
        public bool showRadius;

        private GameObject player;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
            StartCoroutine(PlayerLocator());
        }

        private IEnumerator PlayerLocator()
        {
            WaitForSeconds wait = new WaitForSeconds(0.1f);

            while (true)
            {
                yield return wait;
                CheckIfPlayerInSight();
            }
        }

        private void CheckIfPlayerInSight()
        {
            Collider2D[] rangeCheck =
                Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

            if (rangeCheck.Length > 0)
            {
                Transform target = rangeCheck[0].transform;
                Vector2 directionToTarget = (target.position - transform.position).normalized;

                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget,
                        obstructionLayer))
                {
                    playerVisible = true;
                }
                else
                {
                    playerVisible = false;
                }
            }
            else if (playerVisible)
            {
                playerVisible = false;
            }
        }

        private void OnDrawGizmos()
        {
            if (showRadius)
            {
                Gizmos.color = Color.white;
                //UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

                if (playerVisible)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawLine(transform.position, player.transform.position);
                }
            }
        }
    }
}