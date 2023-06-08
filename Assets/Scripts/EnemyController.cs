using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;



/// <summary>
/// Controls the behavior of enemies in the game.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for controlling enemies in the game.
    /// </summary>
    public class EnemyController : MonoBehaviour
    {
        /// <summary>
        /// The type of enemy.
        /// </summary>
        public enum EnemyType
        {
            Minion_Small, // Melee - sword etc...
            Minion_Medium, // Basic weapon
            Minion_Large, // Strong weapon
            Boss // Hardcore mf
        }

        public float speed;
        public float minimumDistance;
        public float hp;
        public EnemyType _enemyType;

        public Animator _animator;

        public GameObject weapon;
        private WeaponController _weaponController;
        private Animator weaponAnim;

        private Rigidbody2D rb;
        private Vector3 oldPos;
        private GameObject player;
        private PlayerDetection _playerDetection;

        void Awake()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();

            player = GameObject.FindWithTag("Player");
            _playerDetection = gameObject.GetComponent<PlayerDetection>();

            _weaponController = weapon.transform.transform.GetComponent<WeaponController>();

            if (weapon != null)
            {
                weaponAnim = weapon.GetComponent<Animator>();
            }

            if (_enemyType == EnemyType.Minion_Medium)
            {
                InvokeRepeating("EnemyFire", 2f, 2f);
            }

            if (_enemyType == EnemyType.Minion_Large)
            {
                InvokeRepeating("EnemyFire", 2f, 5f);
            }
        }

        private void FixedUpdate()
        {
            oldPos = transform.position;
            if (_playerDetection.playerVisible)
            {
                rb.MovePosition(player.transform.position);
                transform.position =
                    Vector2.MoveTowards(transform.position, player.transform.position,
                        speed * Time.deltaTime);

                if (transform.position.x < oldPos.x)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else if (transform.position.x > oldPos.x)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }

            if (transform.position != oldPos)
            {
                _animator.SetBool("Moving", true);
            }
            else if (transform.position == oldPos)
            {
                _animator.SetBool("Moving", false);
            }
        }

        /// <summary>
        /// Called when a collider enters the trigger collider of the object.
        /// </summary>
        /// <param name="col">The collider that entered the trigger.</param>
        private void OnTriggerEnter2D(Collider2D col)
        {
            // Melee attack
            if (col.gameObject.tag == "Player")
            {
                weaponAnim.SetBool("Attack", true);
            }
        }

        /// <summary>
        /// Called when a collider exits the trigger collider of the object.
        /// </summary>
        /// <param name="col">The collider that exited the trigger.</param>
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                weaponAnim.SetBool("Attack", false);
            }
        }

        /// <summary>
        /// Perform an enemy attack.
        /// </summary>
        private void EnemyFire()
        {
            if (_playerDetection.playerVisible)
            {
                _weaponController.Fire();
                Debug.Log("Enemy fired");
            }
        }

        /// <summary>
        /// Inflict damage to the enemy.
        /// </summary>
        /// <param name="amount">The amount of damage to inflict.</param>
        public void Damage(float amount)
        {
            hp -= amount;
            if (hp <= 0)
            {
                Death();
            }
        }

        /// <summary>
        /// Perform death actions for the enemy.
        /// </summary>
        private void Death()
        {
            _animator.SetBool("Moving", false);
            Destroy(transform.gameObject);
        }
    }
}
