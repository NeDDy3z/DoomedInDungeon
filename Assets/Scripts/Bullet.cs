using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    
    private float damage;
    private float speed;

    private GameObject weapon;
    private WeaponFirearm _weaponFirearm;
    
    private PlayerManager _playerManager;
    private GameObject enemy;


    void Awake()
    {
        _playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        _weaponFirearm = transform.parent.transform.parent.gameObject.GetComponent<WeaponFirearm>();
        
        damage = _weaponFirearm.damage;
        speed = _weaponFirearm.bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.IsTouchingLayers(8)) Destroy(this, 1); //runs into wall, it destroys itself
        
        if (col.gameObject.tag == "HitboxPlayer" && _weaponFirearm._EntityType == WeaponFirearm.EntityType.Enemy)
        {
            _playerManager.Damage(damage);
            Destroy(this, 1);
        }

        if (col.gameObject.tag == "HitboxEnemy" && _weaponFirearm._EntityType == WeaponFirearm.EntityType.Player)
        {
            col.gameObject.transform.parent.transform.parent.GetComponent<EnemyController>().Damage(damage);
            Destroy(this, 1);
        }
    }
}
