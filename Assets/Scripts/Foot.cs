using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag =="Ground")
        {
            playerMovement.canJump = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        playerMovement.canJump = false;
    }
}
