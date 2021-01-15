using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance;


    private string init = "Game Started";
    void Awake()
    {
        makeInstance();
        inilialized();
    }

    void makeInstance()
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

    void inilialized()
    {
        if (!PlayerPrefs.HasKey(init))
        {
            PlayerPrefs.SetInt("Level1", 1);
            for (int i = 2; i < 6; i++)
            {
                PlayerPrefs.SetInt("Level" + i, 0);
            }
            PlayerPrefs.SetInt("music", 1);
            PlayerPrefs.SetString("selectedLevel", "Level1");
            PlayerPrefs.SetInt(init, 1);
        }
    }


    public void setMusicState(bool state)
    {
        PlayerPrefs.SetInt("music", state ? 1 : 0);
    }

    public bool musicState()
    {
        return (PlayerPrefs.GetInt("music") == 1) ? true : false;
    }

    public void setSelectedLevel(string level)
    {
        PlayerPrefs.SetString("selectedLevel", level);
    }

    public string getSelectedLevel()
    {
        return PlayerPrefs.GetString("selectedLevel");
    }


    public bool isUnlockLevel(string level){
        Debug.Log(level + " " + PlayerPrefs.GetInt(level));
        return PlayerPrefs.GetInt(level) == 0 ? false : true;
    }

    public int getLevelScore(string level){
        return PlayerPrefs.GetInt(level);
    }

    public void setLevelScore(string level, int score){
        PlayerPrefs.SetInt(level,score);
    }

    public void unlockLevel(string name){
        PlayerPrefs.SetInt(name, 1);
         Debug.Log(name + " " + PlayerPrefs.GetInt(name));
    }
}