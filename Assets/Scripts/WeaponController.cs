using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float damage;
    public float bulletSpeed;
    
    public WeaponType _weaponType;

    public Transform shootingPoint;
    public Animator _animator;
    public GameObject bulletPrefab;

    private GameManager _gameManager;

    public enum WeaponType
    {
        Handgun,
        Rifle,
        Shotgun
    }

    void Start()
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
            
        }
    }
    
    
}
