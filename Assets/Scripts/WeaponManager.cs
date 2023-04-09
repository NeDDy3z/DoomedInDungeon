using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float damage;
    public WeaponType _weaponType;
    public Animator _animator;

    private BoxCollider2D meeleWeaponCollider;

    private GameObject player;
    private PlayerController _playerController;
    private PlayerManager _playerManager;

    private EnemyController _enemyController;
    
    public enum WeaponType
    {
        Melee,
        Bullet
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (_weaponType == WeaponType.Melee) meeleWeaponCollider = gameObject.GetComponent<BoxCollider2D>();
        
        player = GameObject.FindWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();
        _playerManager = player.GetComponent<PlayerManager>();

        _enemyController = transform.gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
    }

    public void Hit()
    {
        if (_playerManager.hp > 0) _playerManager.Damage(damage);
    }
    
    public void Fire()
    {
        
    }
    
}
