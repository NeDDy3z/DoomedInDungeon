using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
        }

        if (PlayerPrefs.GetInt("music") == 1)
        {
            _audioSource.time = Random.Range(0, _audioSource.clip.length - 1f);
            _audioSource.Play();
        }
        else
        {
            _audioSource.Pause();
        }


        if (!PlayerPrefs.HasKey("sounds"))
        {
            PlayerPrefs.SetInt("music", 1);
        }
    }
}