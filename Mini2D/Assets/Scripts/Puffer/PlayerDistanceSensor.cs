using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistanceSensor : MonoBehaviour
{
    /*
     * NOTE! This script REQUIRES the player to possess the "Player" tag to function!
     */

    public delegate void TriggerStatus(bool status);
    public static event TriggerStatus OnTriggerStatus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(OnTriggerStatus != null)
            {
                OnTriggerStatus(true);
            }
            else
            {
                throw new System.Exception("No action set to trigger!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (OnTriggerStatus != null)
            {
                OnTriggerStatus(false);
            }
            else
            {
                throw new System.Exception("No action set to player detection trigger!");
            }
        }
    }
}
