using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public int collisionCounter = 0;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "NPC")
        {
            collisionCounter++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "NPC")
        {
            collisionCounter--;
        }
    }
}