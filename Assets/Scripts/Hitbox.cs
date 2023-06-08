using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Detects collisions with entities (player or enemy) in the game.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for detecting collisions with entities (player or enemy) in the game.
    /// </summary>
    public class Hitbox : MonoBehaviour
    {
        public enum Entity
        {
            Player,
            Enemy
        }

        public Entity _entity;

        private GameObject player;
        private GameObject enemy;

        private PlayerController _playerController;
        private EnemyController _enemyController;


        void Start()
        {
            if (_entity == Entity.Player)
            {
                player = GameObject.FindWithTag("Player");
                _playerController = player.GetComponent<PlayerController>();
            }
            else
            {
                enemy = transform.gameObject;
                _enemyController = enemy.GetComponent<EnemyController>();
            }
        }
    }
}
