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
    private PlayerController _playerController;


    // Start is called before the first frame update
    void Awake()
    { 
        meeleWeaponCollider = gameObject.GetComponent<BoxCollider2D>();
        
        player = GameObject.FindWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();

    }

    public void Hit()
    {
        if (_playerController.hp > 0) _playerController.Damage(damage);
    }
}
