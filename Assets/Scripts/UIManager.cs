using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Manages the user interface elements related to the player's health (HP) and coins.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for updating and managing the user interface elements.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        /// <summary>
        /// The image representing the player's health bar.
        /// </summary>
        public Image hpImg;

        /// <summary>
        /// The text displaying the player's HP value.
        /// </summary>
        public TextMeshProUGUI hpText;

        /// <summary>
        /// The text displaying the amount of coins the player has.
        /// </summary>
        public TextMeshProUGUI coinsAmount;

        /// <summary>
        /// The text displaying the changes in the player's coins value.
        /// </summary>
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

        /// <summary>
        /// Updates the new data for HP and coins from the player controller.
        /// </summary>
        public void UpdateNewData()
        {
            hp = _playerController.hp;
            coins = _playerController.coins;

            Debug.Log("HP: " + hp + "\nCoins: " + coins);
        }

        /// <summary>
        /// Updates the old data for HP and coins to keep track of previous values.
        /// </summary>
        public void UpdateOldData()
        {
            oldHp = hp;
            oldCoins = coins;

            Debug.Log("HP: " + hp + "\nCoins: " + coins);
        }

        /// <summary>
        /// Updates the HP user interface element based on the player's current HP value.
        /// </summary>
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

        /// <summary>
        /// Updates the coins user interface element based on the player's current coins value.
        /// </summary>
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