using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool playerVisible { get; private set; }

    public LayerMask targetLayer;
    public LayerMask obstructionLayer;

    public float radius = 2.5f;
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
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

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
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

            if (playerVisible)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, player.transform.position);
            }
        }
    }
}