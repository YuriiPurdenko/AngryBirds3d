using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelMenuControllerScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Button[] buttons;
    void Start()
    {
        checkCompleteLevels();
    }

    void checkCompleteLevels()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            var tempColor = buttons[i].image.color;
            tempColor.a = 0.5f;
            buttons[i].onClick.RemoveAllListeners();
            if (GameManager.instance.isUnlockLevel(buttons[i].name))
            {
                int x = i;
                buttons[i].onClick.AddListener(() => loadLevel(buttons[x].name));
                tempColor.a = 1f;
            }
            buttons[i].image.color = tempColor;
        }
    }


    void loadLevel(string name)
    {
        SceneManager.LoadScene(name);
        GameManager.instance.setSelectedLevel(name);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
