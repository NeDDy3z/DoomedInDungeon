using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : MonoBehaviour
{
    public float damage;
    public Animator _animator;

    private BoxCollider2D meeleWeaponCollider;

    private GameObject player;
    private PlayerManager _playerManager;


    // Start is called before the first frame update
    void Awake()
    { 
        meeleWeaponCollider = gameObject.GetComponent<BoxCollider2D>();
        
        player = GameObject.FindWithTag("Player");
        _playerManager = player.GetComponent<PlayerManager>();
        
    }

    public void Hit()
    {
        if (_playerManager.hp > 0) _playerManager.Damage(damage);
    }
}
