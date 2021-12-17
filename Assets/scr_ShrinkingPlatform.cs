using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ShrinkingPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER HAS LANDED ON PLATORM");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER HAS LEFT THE PLATORM");
        }
    }
}
