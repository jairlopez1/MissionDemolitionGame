using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelsComplete;

    void Start()
    {

        for(int i = 0; i < 12; i++)
        {
            levelsComplete.transform.GetChild(i).GetComponent<RawImage>().enabled = false;

            int curLevel = i + 1;

            if (PlayerPrefs.HasKey("Level" + curLevel + "Complete")) {
                if (PlayerPrefs.GetInt("Level" + curLevel + "Complete") == 1)
                {
                    levelsComplete.transform.GetChild(i).GetComponent<RawImage>().enabled = true;
                }
            }
            else
            {
                PlayerPrefs.SetInt("Level" + curLevel + "Complete", 0);
            }
        }

     }
    public void goToLevel()
    {
        string level = EventSystem.current.currentSelectedGameObject.name;

        switch (level)
        {
            case "Level 1":
                PlayerPrefs.SetInt("Level", 0);
                break;
            case "Level 2":
                PlayerPrefs.SetInt("Level", 1);
                break;
            case "Level 3":
                PlayerPrefs.SetInt("Level", 2);
                break;
            case "Level 4":
                PlayerPrefs.SetInt("Level", 3);
                break;
            case "Level 5":
                PlayerPrefs.SetInt("Level", 4);
                break;
            case "Level 6":
                PlayerPrefs.SetInt("Level", 5);
                break;
            case "Level 7":
                PlayerPrefs.SetInt("Level", 6);
                break;
            case "Level 8":
                PlayerPrefs.SetInt("Level", 7);
                break;
            case "Level 9":
                PlayerPrefs.SetInt("Level", 8);
                break;
            case "Level 10":
                PlayerPrefs.SetInt("Level", 9);
                break;
            case "Level 11":
                PlayerPrefs.SetInt("Level", 10);
                break;
            case "Level 12":
                PlayerPrefs.SetInt("Level", 11);
                break;
        }

        SceneManager.LoadScene("_Scene_0");
    }
}
