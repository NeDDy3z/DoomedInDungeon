using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image hpImg;
    public TextMeshProUGUI hpText;

    public TextMeshProUGUI coinsAmount;
    public TextMeshProUGUI coinsText;

    private PlayerController _playerController;
    private float hp;
    private float oldHp;
    private float maxHp;
    private float coins;
    private float oldCoins;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        coinsAmount.text = coins.ToString();

        maxHp = 200;
    }


    void LoadData()
    {
        
    }

    void SaveData()
    {
        string path = Application.persistentDataPath + "/savegame.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        byte[] data = System.Text.Encoding.UTF8.GetBytes("lol");
        stream.Write(data, 0, data.Length);
        
        stream.Close();
    }
    
    public void UpdateData()
    {
        hp = _playerController.hp;
        oldHp = hp;
        maxHp = _playerController.maxHp;
        coins = _playerController.coins;
        oldCoins = coins;
    }

    public void UpdateHP()
    {
        hp = _playerController.hp;
        if (hp >= oldHp)
        {
            int temp = Convert.ToInt32(hp) - Convert.ToInt32(oldHp);

            if (temp >= 0) hpText.text = "+" + temp;
            else hpText.text = "-" + temp;
            
            hpText.color = Color.green;
        }
        else
        {
            hpText.text = (Convert.ToInt32(hp) - Convert.ToInt32(oldHp)).ToString();
            hpText.color = Color.red;
        }
        oldHp = hp;
        
        hpImg.rectTransform.sizeDelta = new Vector2(hp, 10);
        
        hpText.CrossFadeAlpha(1, 0, false);
        hpText.CrossFadeAlpha(0, 5, true);
    }

    public void UpdateCoins()
    {
        coinsAmount.text = coins.ToString();
        
        coins = _playerController.coins;
        if (coins > oldCoins)
        {
            coinsText.text = "+" + (Convert.ToInt32(coins) - Convert.ToInt32(oldCoins));
        }
        else
        {
            coinsText.text = "-" + (Convert.ToInt32(oldCoins) - Convert.ToInt32(coins));
        }
        oldCoins = coins;
        
        hpText.CrossFadeAlpha(1, 0, false);
        hpText.CrossFadeAlpha(0, 5, true);
    }
    
}