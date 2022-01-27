using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{

    public AudioSource audioSource;
    private bool audioPlayed;


    void Start()
    {
        audioPlayed = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Block")
        {
            if(audioPlayed == false)
            {
                audioSource.Play();
                audioPlayed = true;
            }
        }
       
    }
}
