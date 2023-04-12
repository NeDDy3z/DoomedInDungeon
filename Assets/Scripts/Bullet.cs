using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public float damage;
    public float speed;
    public FiredBy _firedBy;
    
    private PlayerController _playerController;

    public enum FiredBy
    {
        Player,
        Enemy
    }

    void Start()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "WallCollision") Destroy(transform.gameObject); //runs into wall, it destroys itself

        if (col.gameObject.tag == "HitboxPlayer" && _firedBy == FiredBy.Enemy)
        {
            _playerController.Damage(damage);
            Destroy(transform.gameObject);
        }

        if (col.gameObject.tag == "HitboxEnemy" && _firedBy == FiredBy.Player)
        {
            col.gameObject.transform.parent.GetComponent<EnemyController>().Damage(damage);
            Destroy(transform.gameObject);
        }
    }
}
