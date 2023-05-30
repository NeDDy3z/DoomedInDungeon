using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSwitcher : MonoBehaviour
{
    private GameManager _gameManager;
    private PlayerController _playerController;

    public int sceneBuildIndex;
    public bool Demo;

    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "HitboxPlayer")
            if (sceneBuildIndex == 999) _gameManager.End();
            else SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
