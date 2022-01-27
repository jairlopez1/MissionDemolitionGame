using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}




public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S;

    [Header("Set in Inspector")]
    public TextMeshProUGUI uitLevel;
    public TextMeshProUGUI uitShots;
    public Button uitButton;
    public TextMeshProUGUI uitButtontext;
    public Vector3 castlePos;
    public GameObject[] castles;
    public AudioSource winAudio;

    [Header("Set Dynamically")]
    static public int level;
    public int levelMax;
    public int shotsTaken;
    static public int currentShots;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";

    void Start()
    {
        S = this;


        if (PlayerPrefs.HasKey("Level") == true)
        {
            level = PlayerPrefs.GetInt("Level");                   
        }
        else
        {
            level = 0;
        }

        if(PlayerPrefs.HasKey("CurrentLevel") == true && PlayerPrefs.HasKey("gameRestarted")) 
        {
            if(PlayerPrefs.GetInt("gameRestarted") == 1)
            {
                level = PlayerPrefs.GetInt("CurrentLevel");
                PlayerPrefs.SetInt("gameRestarted", 0);
            }
        }
        levelMax = castles.Length;
        StartLevel();
    }

    void StartLevel()
    {
        if(castle != null)
        {
            Destroy(castle);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        GameObject[] cos = GameObject.FindGameObjectsWithTag("ClearProjectile");
        foreach (GameObject pTemp in cos)
        {
            Destroy(pTemp);
        }

        GameObject[] fos = GameObject.FindGameObjectsWithTag("FastProjectile");
        foreach (GameObject pTemp in fos)
        {
            Destroy(pTemp);
        }

        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;

        SwitchView("Show Both");

        ProjectileLine.S.Clear();

        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScreen");
        }

        UpdateGUI();

        if((mode == GameMode.playing)&& Goal.goalMet)
        {
            winAudio.Play();
            mode = GameMode.levelEnd;
            SwitchView("Show Both");
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        level++;
        if(level == levelMax)
        {
            level = 0;
        }
        currentShots = 0;
        StartLevel();
    }

    public void SwitchView(string eView ="")
    {
        if(eView == "")
        {
            eView = uitButtontext.text;
        }

        showing = eView;
        switch(showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButtontext.text = "Show Castle";
                break;
            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButtontext.text = "Show Both";
                break;
            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButtontext.text = "Show Slingshot";
                break;
        }
    }

    public static void ShotFired()
    {
        S.shotsTaken++;
        currentShots = S.shotsTaken;
    }


    public void restartLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", level);
        PlayerPrefs.SetInt("gameRestarted", 1);
        SceneManager.LoadScene("_Scene_0");
    }

}
