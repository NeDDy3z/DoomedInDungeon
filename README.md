# DoomedInDungeon
Final project - 3rd year of HS

Doomed in Dungeon Documentation
 
GameManager script
Description
The GameManager script manages the overall game state and user interface elements. It handles the transition between different game states such as the main menu, game, pause menu, levels, options, credits, and trading. It also controls the player's death, sound settings, and the overall flow of the game.
Public Variables
•	public GameObject mainMenu: Reference to the main menu UI.
•	public GameObject pauseMenu: Reference to the pause menu UI.
•	public GameObject levels: Reference to the levels UI.
•	public GameObject options: Reference to the options UI.
•	public GameObject credits: Reference to the credits UI.
•	public GameObject death: Reference to the death UI.
•	public GameObject gui: Reference to the in-game UI.
•	public GameObject ending: Reference to the ending UI.
•	public SoundEffects _soundEffects: Reference to the SoundEffects script.
•	public GameState gameState: Current game state.
•	public GameObject player: Reference to the player GameObject.
Enums
•	public enum GameState: Possible game states.
Methods
•	void Start(): Called before the first frame update. Initializes the game state and activates the appropriate UI elements based on the current scene.
•	void Update(): Called once per frame. Handles input for game pause and player death.
•	void UIOff(): Deactivates all UI elements.
•	public void StartGame(): Starts the game and transitions to the game scene.
•	public void Menu(): Displays the main menu UI.
•	public void Levels(): Displays the levels UI.
•	public void Options(): Displays the options UI.
•	public void Credits(): Displays the credits UI.
•	public void ExitGame(): Exits the game.
•	public void End(): Ends the game.
•	public void Pause(): Pauses or resumes the game.
•	public void Death(): Handles player death.
•	public void Sound(): Toggles sound on or off.
•	public void Music(): Toggles music on or off.
________________________________________
UIManager script
Description
The UIManager script manages the user interface elements related to the player's health (HP) and coins. It updates and displays the player's current HP and coins values. It also handles the animations and text changes for HP and coins.
Public Variables
•	public Image hpImg: Image representing the player's health bar.
•	public TextMeshProUGUI hpText: Text displaying the player's HP value.
•	public TextMeshProUGUI coinsAmount: Text displaying the amount of coins the player has.
•	public TextMeshProUGUI coinsText: Text displaying the changes in the player's coins value.
Methods
•	void Start(): Called before the first frame update. Initializes the UI elements and updates the initial values.
•	public void UpdateNewData(): Updates the new data for HP and coins from the player controller.
•	public void UpdateOldData(): Updates the old data for HP and coins to keep track of previous values.
•	public void UpdateHP(): Updates the HP user interface element based on the player's current HP value.
•	public void UpdateCoins(): Updates the coins user interface element based on the player's current coins value.
________________________________________
LevelSwitch script
Description
The LevelSwitch script handles level switching functionality. It allows the player to switch to a specified level based on the level number.
Methods
•	public void SwitchToMap(int number): Switches to the specified level.
________________________________________
SoundEffects script
Description 
The SoundEffects script manages the audio source and sound settings for. the game. It handles playing different sound effects such as player movement, collisions, pickups, and other game events. It also provides methods to control the sound volume and mute the sound.

Public Variables
•	public AudioSource audioSource: Reference to the AudioSource component.
•	public AudioClip[] movementSounds: Array of movement sound effects.
•	public AudioClip[] collisionSounds: Array of collision sound effects.
•	public AudioClip pickupSound: Sound effect for pickups.
•	public AudioClip gameOverSound: Sound effect for game over.
•	public float volume: Sound volume.
Methods
•	public void PlayMovementSound(): Plays a random movement sound effect from the movementSounds array.
•	public void PlayCollisionSound(): Plays a random collision sound effect from the collisionSounds array.
•	public void PlayPickupSound(): Plays the pickup sound effect.
•	public void PlayGameOverSound(): Plays the game over sound effect.
•	public void SetVolume(float newVolume): Sets the sound volume to the specified value.
•	public void MuteSound(): Mutes the sound by setting the volume to 0.
•	public void UnmuteSound(): Unmutes the sound by restoring the previous volume value.
________________________________________

