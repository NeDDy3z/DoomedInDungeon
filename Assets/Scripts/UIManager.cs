using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace Scripts
{
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

            UpdateNewData();
            UpdateOldData();
        }



        public void UpdateNewData()
        {
            hp = _playerController.hp;
            coins = _playerController.coins;

            Debug.Log("HP: " + hp + "\nCoins: " + coins);
        }

        public void UpdateOldData()
        {
            oldHp = hp;
            oldCoins = coins;

            Debug.Log("HP: " + hp + "\nCoins: " + coins);
        }


        public void UpdateHP()
        {
            UpdateNewData();

            if (hp >= oldHp)
            {
                hpText.color = Color.green;
                int temp = Convert.ToInt32(hp) - Convert.ToInt32(oldHp);

                hpText.text = "+" + temp;
            }
            else if (hp <= oldHp)
            {
                hpText.color = Color.red;
                hpText.text = (Convert.ToInt32(hp) - Convert.ToInt32(oldHp)).ToString();
            }

            oldHp = hp;

            hpImg.rectTransform.sizeDelta = new Vector2(hp, 10);

            hpText.CrossFadeAlpha(1, 0, false);
            hpText.CrossFadeAlpha(0, 5, true);

            UpdateOldData();
        }

        public void UpdateCoins()
        {
            UpdateNewData();

            coinsAmount.text = coins.ToString();
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

            UpdateOldData();
        }

    }
}
