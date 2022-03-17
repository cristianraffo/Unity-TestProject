using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBuffs : MonoBehaviour
{
    public PlayerMovement player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.runSpeed = 8;
            player.jumpForce = 6;                 
        }
    }
}
