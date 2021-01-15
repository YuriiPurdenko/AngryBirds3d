using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControllerScript : MonoBehaviour
{

    public static MusicControllerScript instance;

    private AudioSource music;



    void Awake()
    {
        MakeSingleton();
        music = GetComponent<AudioSource>();
    }
    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(bool play)
    {
        if (play)
        {
            if (!music.isPlaying)
            {
                music.Play();
            }
        }
        else
        {
            if (music.isPlaying)
            {
                music.Stop();
            }
        }
    }
}