using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private float speed;

    private GameObject weapon;
    private WeaponFirearm _weaponFirearm;
    
    private GameObject player;
    private GameObject enemy;
    private PlayerManager _playerManager;
    private EnemyController _enemyController;
    
    
    void Start()
    {
        weapon = transform.gameObject;
        _weaponFirearm = weapon.GetComponent<WeaponFirearm>();
        
        damage = _weaponFirearm.damage;
        speed = _weaponFirearm.bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.IsTouchingLayers(9)) Destroy(this); //runs into wall, it destroys itself
        
        if (col.gameObject.tag == "HitboxPlayer")
        {
            _playerManager.Damage(damage);
            Destroy(this);
        }

        if (col.gameObject.tag == "HitboxEnemy")
        {
            _enemyController.Damage(damage);
            Destroy(this);
        }
    }
}
