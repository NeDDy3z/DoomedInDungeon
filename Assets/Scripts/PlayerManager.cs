using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float hp = 200;
    private float maxHp = 200;
    
    public Image hpImg;
    public TextMeshProUGUI hpText;

    public float coins = 0;
    public TextMeshProUGUI coinsAmount;
    public TextMeshProUGUI coinsText;

    // Start is called before the first frame update
    void Start()
    {
        hpImg.rectTransform.sizeDelta = new Vector2(hp, 10);
        coinsAmount.text = coins.ToString();
    }

    #region HP
    public void Heal(int amount)
    {
        if (hp < maxHp) hp += amount;
        if (hp > maxHp) hp -= hp - maxHp;

        hpImg.rectTransform.sizeDelta = new Vector2(hp, 10);
        hpText.text = "+" + amount;
        hpText.color = Color.green;
        hpText.CrossFadeAlpha(1,0,false);
        hpText.CrossFadeAlpha(0,5,true);
        
        Debug.Log("Heal: +"+ amount);
    }
    
    public void Damage(int amount)
    {
        hp -= amount;
        if (hp <= 0) Died();
        
        hpImg.rectTransform.sizeDelta = new Vector2(hp, 10);
        hpText.text = "-" + amount;
        hpText.color = Color.red;
        hpText.CrossFadeAlpha(1,0,false);
        hpText.CrossFadeAlpha(0,5,true);

        Debug.Log("Damage: -"+ amount);
    }

    private void Died()
    {
        Debug.Log("Death");
        GameObject.FindWithTag("GameController").GetComponent<GameManager>().Death();
    }
    #endregion
    
    #region Coins
    public void AddCoins(int amount)
    {
        coins += amount;
        coinsAmount.text = coins.ToString();
        
        coinsText.text = "+" + amount;
        coinsText.CrossFadeAlpha(1,0,false);
        coinsText.CrossFadeAlpha(0,5,true);
        
        Debug.Log("Coins: +"+ amount);
    }

    public void SubtractCoins(int amount)
    {
        coins -= amount;
        coinsAmount.text = coins.ToString();
        
        coinsText.text = "-" + amount;
        coinsText.CrossFadeAlpha(1,0,false);
        coinsText.CrossFadeAlpha(0,5,true);
        
        Debug.Log("Coins: -"+ amount);
    }
    #endregion
}