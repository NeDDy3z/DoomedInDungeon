using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles level switching functionality.
/// </summary>

namespace Scripts
{
    /// <summary>
    /// Class responsible for level switching.
    /// </summary>
    public class LevelSwitch : MonoBehaviour
    {
        /// <summary>
        /// Switches to the specified level.
        /// </summary>
        /// <param name="number">The number of the level to switch to.</param>
        public void SwitchToMap(int number)
        {
            SceneManager.LoadScene(number, LoadSceneMode.Single);
            Debug.Log("User selected level " + number + " from menu");
        }
    }
}
