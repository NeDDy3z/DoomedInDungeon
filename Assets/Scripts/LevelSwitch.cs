using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class LevelSwitch : MonoBehaviour
    {
        public void SwitchToMap(int number)
        {
            SceneManager.LoadScene(number, LoadSceneMode.Single);
            Debug.Log("User selected level " + number + " from menu");
        }
    }
}