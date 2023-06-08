using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


/// <summary>
/// Controls the player character, manages player health and coins, and interacts with the UI.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for controlling the player.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// The current health points of the player.
        /// </summary>
        public float hp;

        /// <summary>
        /// The maximum health points of the player.
        /// </summary>
        public float maxHp;

        /// <summary>
        /// The current number of coins collected by the player.
        /// </summary>
        public float coins;

        /// <summary>
        /// The movement speed of the player.
        /// </summary>
        public float movementSpeed = 2f;

        /// <summary>
        /// Reference to the character GameObject.
        /// </summary>
        public GameObject character;

        /// <summary>
        /// Reference to the Animator component of the character.
        /// </summary>
        public Animator _animator;

        private Rigidbody2D rb;

        private bool freeze;
        private float moveHorizontal;
        private float moveVertical;
        private Vector3 mousePos;

        private UIManager _uiManager;
        private GameManager _gameController;

        private bool movehor;
        private bool movever;

        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            _uiManager = GameObject.FindWithTag("GameController").gameObject.transform.GetChild(0)
                .GetComponent<UIManager>();
            _gameController = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        }

        private void Update()
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

            if (moveHorizontal != 0f)
            {
                movehor = true;
            }
            else
            {
                movehor = false;
            }

            if (moveVertical != 0f)
            {
                movever = true;
            }
            else
            {
                movever = false;
            }

            if (movehor || movever)
            {
                _animator.SetBool("moving", true);
            }
            else
            {
                _animator.SetBool("moving", false);
            }

            var dir = Camera.main.WorldToScreenPoint(transform.position);
            mousePos = Input.mousePosition - dir;
        }

        /// <summary>
        /// Called at a fixed interval for physics-related updates.
        /// </summary>
        void FixedUpdate()
        {
            Vector3 moveInput = new Vector3(
                moveHorizontal * Time.deltaTime * movementSpeed,
                moveVertical * Time.deltaTime * movementSpeed, 0);

            if (!freeze)
            {
                rb.MovePosition(transform.position += moveInput);
            }

            if (mousePos.x < 0)
            {
                character.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            }

            if (mousePos.x > 0)
            {
                character.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        /// <summary>
        /// Freezes or unfreezes the player's movement.
        /// </summary>
        /// <param name="choice">True to freeze the player, false to unfreeze.</param>
        public void Freeze(bool choice)
        {
            freeze = choice;

            Debug.Log("Player frozen: " + freeze);
        }

        /// <summary>
        /// Sets the player's health points to the maximum value.
        /// </summary>
        public void SetMaxHP()
        {
            hp = maxHp;
            _uiManager.UpdateHP();

            Debug.Log("HP set to max");
        }

        /// <summary>
        /// Heals the player by the specified amount.
        /// </summary>
        /// <param name="amount">The amount of health to restore.</param>
        public void Heal(float amount)
        {
            hp += amount;

            if (hp > maxHp)
            {
                hp -= hp - maxHp;
            }

            _uiManager.UpdateHP();

            Debug.Log("Healed: +" + amount);
        }

        /// <summary>
        /// Damages the player by the specified amount.
        /// </summary>
        /// <param name="amount">The amount of damage to inflict.</param>
        public void Damage(float amount)
        {
            hp -= amount;
            if (hp <= 0)
            {
                Died();
            }

            _uiManager.UpdateHP();

            Debug.Log("Damaged: -" + amount);
        }

        private void Died()
        {
            GameObject.FindWithTag("GameController").GetComponent<GameManager>().Death();
            Debug.Log("Player died");
        }

        /// <summary>
        /// Adds the specified amount of coins to the player's collection.
        /// </summary>
        /// <param name="amount">The amount of coins to add.</param>
        public void AddCoins(float amount)
        {
            coins += amount;
            _uiManager.UpdateCoins();

            Debug.Log("Coins " + (coins - amount) + ": +" + amount + " = " + coins);
        }

        /// <summary>
        /// Subtracts the specified amount of coins from the player's collection.
        /// </summary>
        /// <param name="amount">The amount of coins to subtract.</param>
        public void SubtractCoins(float amount)
        {
            coins -= amount;
            _uiManager.UpdateCoins();

            Debug.Log("Coins: -" + amount);
        }
    }
}