using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;
    private bool isColliding;


    void Start()
    {
        int curLevel = MissionDemolition.level + 1;
        PlayerPrefs.SetInt("Level" + curLevel + "Hits", 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "ClearProjectile" || other.gameObject.tag == "FastProjectile")
        {
            int curLevel = MissionDemolition.level + 1;
            goalMet = checkForWin();
            if (isColliding) return;
            isColliding = true;
            gameObject.SetActive(false);
        }
    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "ClearProjectile" || other.gameObject.tag == "FastProjectile")
        {
            int curLevel = MissionDemolition.level + 1;

            //StartCoroutine(WaitToDestroy(gameObject));
            goalMet = checkForWin();

            gameObject.SetActive(false);
        }
    }

    private bool checkForWin()
    {
        bool goalMet = false;

        int curLevel = MissionDemolition.level + 1;
        int numOfHits = 0;

        if (curLevel == 1 || curLevel == 2 || curLevel == 7)
        {
            PlayerPrefs.SetInt("Level" + curLevel + "Complete", 1);
            goalMet = true;
        }
        else if (curLevel == 3 || curLevel == 4 || curLevel == 5)
        {
            numOfHits = PlayerPrefs.GetInt("Level" + curLevel + "Hits") + 1;
            print(numOfHits);
            if (numOfHits == 2)
            {
                PlayerPrefs.SetInt("Level" + curLevel + "Complete", 1);
                goalMet = true;
            }
            else
            {
                PlayerPrefs.SetInt("Level" + curLevel + "Hits", 1);
            }
        }
        else if (curLevel == 6)
        {
            numOfHits = PlayerPrefs.GetInt("Level" + curLevel + "Hits") + 1;
            print(numOfHits);
            if (numOfHits == 6)
            {
                PlayerPrefs.SetInt("Level" + curLevel + "Complete", 1);
                goalMet = true;
            }
            else
            {
                PlayerPrefs.SetInt("Level" + curLevel + "Hits", numOfHits);
            }
        }
        else if (curLevel == 8 )
        {
            numOfHits = PlayerPrefs.GetInt("Level" + curLevel + "Hits") + 1;
            print(numOfHits);
            if (numOfHits == 3)
            {
                PlayerPrefs.SetInt("Level" + curLevel + "Complete", 1);
                goalMet = true;
            }
            else
            {
                PlayerPrefs.SetInt("Level" + curLevel + "Hits", numOfHits);
            }
        }
        else if (curLevel == 9 || curLevel == 10 || curLevel == 12 || curLevel == 11)
        {
            numOfHits = PlayerPrefs.GetInt("Level" + curLevel + "Hits") + 1;
            print(numOfHits);
            if (numOfHits == 5)
            {
                PlayerPrefs.SetInt("Level" + curLevel + "Complete", 1);
                goalMet = true;
            }
            else
            {
                PlayerPrefs.SetInt("Level" + curLevel + "Hits", numOfHits);
            }
        }


        return goalMet;
    }


    void Update()
    {
        isColliding = false;
    }




}
