using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Scripts
{
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
