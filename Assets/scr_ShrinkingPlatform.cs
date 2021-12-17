using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ShrinkingPlatform : MonoBehaviour
{

    public float rateOfShrink;
    public float waitTimeBeforeGrowing; 

    private Animator animator;
    //private GameObject centerOfPlatform; 

    private bool isShrinking = false;
    private float timeSincePlayerContact = 0;
    private AudioSource[] audioSources; 



    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        audioSources = gameObject.GetComponents<AudioSource>();
        //centerOfPlatform = gameObject.transform.GetChild(0).gameObject;
    }


    private void FixedUpdate()
    {
        if (isShrinking)
        {
            gameObject.transform.localScale *= (rateOfShrink);
        }
        else
        {
            timeSincePlayerContact += Time.deltaTime;

            if (timeSincePlayerContact >= waitTimeBeforeGrowing && gameObject.transform.localScale.x < 1f)
            {
                gameObject.transform.localScale *= (2 - rateOfShrink);
                if (!audioSources[1].isPlaying)
                    audioSources[1].Play();
            }
        }

      
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartShrinking();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopShrinking();
        }
    }


    private void StartShrinking()
    {
        isShrinking = true;
        audioSources[0].Play();
    }

    private void StopShrinking()
    {
        Debug.Log("PLAYER HAS LEFT THE PLATORM");
        isShrinking = false;
        timeSincePlayerContact = 0;
        audioSources[0].Stop();
    }
}
