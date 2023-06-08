using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Controls the behavior of bullets in the game.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for controlling bullets in the game.
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D rb;

        public float damage;
        public float speed;
        public FiredBy _firedBy;


        private PlayerController _playerController;

        /// <summary>
        /// The entity that fired the bullet.
        /// </summary>
        public enum FiredBy
        {
            Player,
            Enemy
        }

        void Awake()
        {
            _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

            Debug.Log("Damage: " + damage + " Fired By: " + _firedBy);
        }

        /// <summary>
        /// Called when a collider enters the trigger collider of the bullet.
        /// </summary>
        /// <param name="col">The collider that entered the trigger.</param>
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "WallCollision")
            {
                Destroy(transform.gameObject); // Runs into a wall, destroys itself
            }

            if (col.gameObject.tag == "HitboxPlayer" && _firedBy == FiredBy.Enemy)
            {
                _playerController.Damage(damage);
                Destroy(transform.gameObject);
                Debug.Log("Bullet hit player");
            }

            if (col.gameObject.tag == "HitboxEnemy" && _firedBy == FiredBy.Player)
            {
                col.gameObject.transform.parent.GetComponent<EnemyController>().Damage(damage);
                Destroy(transform.gameObject);
                Debug.Log("Bullet hit enemy");
            }
        }
    }
}
