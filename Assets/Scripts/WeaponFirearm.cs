using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponFirearm : MonoBehaviour
{
    public float damage;
    public float bulletSpeed;

    public GameObject bulletPrefab;

    private GameManager _gameManager;
    private GameObject gun;
    private Animator _animator;
    private Transform shootingPoint;


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        gun = gameObject.transform.GetChild(0).gameObject;
        _animator = gun.transform.GetChild(0).GetComponent<Animator>();
        shootingPoint = gun.transform.GetChild(1).gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.gameState == GameManager.GameState.Game)
        {
            Vector3 dir = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePos = Input.mousePosition - dir;
            var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (mousePos.x < 0) transform.localScale = new Vector3(1, -1, 1);
            if (mousePos.x > 0) transform.localScale = new Vector3(1, 1, 1);

            //Firing on Leftmouse
            if (Input.GetMouseButtonDown(0)) Fire();
        }
    }


    public void Fire()
    {
    }
}