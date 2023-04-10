using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public enum Entity
    {
        player,
        enemy
    }

    public Entity _entity;

    private GameObject player;
    private GameObject enemy;

    private PlayerManager _playerManager;
    private EnemyController _enemyController;


    void Start()
    {
        if (_entity == Entity.player)
        {
            player = GameObject.FindWithTag("Player");
            _playerManager = player.GetComponent<PlayerManager>();
        }
        else
        {
            enemy = transform.gameObject;
            _enemyController = enemy.GetComponent<EnemyController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (_entity == Entity.player) _playerManager.Damage(col.GetComponent<Bullet>().damage);
            else _enemyController.Damage(col.GetComponent<Bullet>().damage);
        }
    }
}