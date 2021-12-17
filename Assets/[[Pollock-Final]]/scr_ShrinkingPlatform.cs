///
/*
Source File:        scr_ShrinkingPlatform
Student Name:       Sam Pollock
Student ID:         101279608
Last Modified:      Dec 17
Description:        Functionality for a floating platform which shrinks then regrows based on contact with the player 
Revision History:   Added Sound Effects.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ShrinkingPlatform : MonoBehaviour
{

    public float rateOfShrink;
    public float waitTimeBeforeGrowing; 

    private Animator animator;

    private bool isShrinking = false;
    private float timeSincePlayerContact = 0;
    private AudioSource[] audioSources; 



    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        audioSources = gameObject.GetComponents<AudioSource>();
    }


    private void FixedUpdate()
    {
        HandleShrinking();  
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

   
    /// Starts shrinking. Called on player enter. 
    private void StartShrinking()
    {
        isShrinking = true;
        audioSources[0].Play();
    }

    /// <summary>
    /// Stops shrinking. Called on player exit.
    /// </summary>
    private void StopShrinking()
    {
        Debug.Log("PLAYER HAS LEFT THE PLATORM");
        isShrinking = false;
        timeSincePlayerContact = 0;
        audioSources[0].Stop();
    }

    /// <summary>
    /// Shrinks if shrinking, counts time since contact with player, and regrows. Called in FixedUpdate. 
    /// </summary>
    private void HandleShrinking()
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

}
