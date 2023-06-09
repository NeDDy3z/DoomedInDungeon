using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls the firing mechanism of a weapon.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for controlling weapon firing.
    /// </summary>
    public class WeaponController : MonoBehaviour
    {
        public float damage;
        public float bulletSpeed;

        public WeaponType _weaponType;

        public Transform shootingPoint;
        public Animator _animator;
        public GameObject bulletPrefab;

        public AudioSource _audioSource;

        private GameManager _gameManager;

        /// <summary>
        /// Enum defining the types of weapons.
        /// </summary>
        public enum WeaponType
        {
            Handgun,
            Rifle,
            Shotgun
        }

        void Awake()
        {
            _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }

        /// <summary>
        /// Fires a projectile from the weapon.
        /// </summary>
        public void Fire()
        {
            if (_gameManager.gameState == GameManager.GameState.Game)
            {
                GameObject projectile = Instantiate(bulletPrefab, shootingPoint.position,
                    shootingPoint.rotation);

                projectile.GetComponent<Rigidbody2D>()
                    .AddForce(shootingPoint.right * bulletSpeed, ForceMode2D.Impulse);

                Bullet projectileBullet = projectile.GetComponent<Bullet>();

                if (gameObject.transform.parent.parent.parent.tag == "Player")
                {
                    projectileBullet._firedBy = Bullet.FiredBy.Player;
                }
                else
                {
                    projectileBullet._firedBy = Bullet.FiredBy.Enemy;
                }

                projectileBullet.damage = damage;
                projectileBullet.speed = bulletSpeed;

                if (PlayerPrefs.GetInt("sound") == 1)
                {
                    _audioSource.time = 0;
                    _audioSource.Play();
                }
            }
        }
    }
}