using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;



/// <summary>
/// Controls the behavior of a boss enemy in the game.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for controlling a boss enemy in the game.
    /// </summary>
    public class BossController : MonoBehaviour
    {
        public float speed;
        public float minimumDistance;
        public float hp;

        public Animator _animator;

        public GameObject weapon;
        private WeaponController _weaponController;
        private Animator weaponAnim;

        private Rigidbody2D rb;
        private Vector3 oldPos;
        private GameObject player;
        private PlayerController _playerController;
        private PlayerDetection _playerDetection;

        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();

            player = GameObject.FindWithTag("Player");
            _playerController = player.GetComponent<PlayerController>();
            _playerDetection = gameObject.GetComponent<PlayerDetection>();

            _weaponController = weapon.transform.transform.GetComponent<WeaponController>();

            InvokeRepeating("Fire", 1f, 15f);
            InvokeRepeating("Fire", 2f, 15f);
            InvokeRepeating("Fire", 3f, 15f);
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
        }

        /// <summary>
        /// Called when a collider enters the trigger collider of the boss.
        /// </summary>
        /// <param name="col">The collider that entered the trigger.</param>
        private void OnTriggerEnter2D(Collider2D col)
        {
            // Melee attack
            if (col.gameObject.tag == "Player")
            {
                _animator.SetTrigger("Attack");
                _playerController.Damage(80);
                Debug.Log("Player damaged by boss - heavy attack");
            }
        }

        private void Fire()
        {
            if (_playerDetection.playerVisible)
            {
                _weaponController.Fire();
                Debug.Log("Boss fired");
            }
        }

        /// <summary>
        /// Applies damage to the boss enemy.
        /// </summary>
        /// <param name="amount">The amount of damage to apply.</param>
        public void Damage(float amount)
        {
            hp -= amount;
            if (hp <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            _animator.SetTrigger("Died");
            Thread.Sleep(5000);
            Destroy(transform.gameObject);
        }
    }
}
