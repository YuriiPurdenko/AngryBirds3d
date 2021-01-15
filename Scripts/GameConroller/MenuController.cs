using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{

    [SerializeField] Button musicButton;
    [SerializeField] Sprite[] sprites;
    // Start is called before the first frame update

    void Start()
    {
        CheckMusic();
    }
    public void playGame()
    {
        string level = GameManager.instance.getSelectedLevel();
        SceneManager.LoadScene(level);
    }

    public void goTolevels()
    {
        SceneManager.LoadScene("LevelsMenu");
    }

    public void CheckMusic()
    {
        if (GameManager.instance.musicState())
        {
            MusicControllerScript.instance.PlayMusic(true);
            musicButton.image.sprite = sprites[0];
        }
        else
        {
            MusicControllerScript.instance.PlayMusic(false);
            musicButton.image.sprite = sprites[1];
        }
    }

    public void musicBtn()
    {
        if (GameManager.instance.musicState())
        {
            GameManager.instance.setMusicState(false);
            MusicControllerScript.instance.PlayMusic(false);
            musicButton.image.sprite = sprites[1];
        }
        else
        {
            GameManager.instance.setMusicState(true);
            MusicControllerScript.instance.PlayMusic(true);
            musicButton.image.sprite = sprites[0];
        }
    }
}
