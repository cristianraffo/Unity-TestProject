using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public bool destroyMouse;
    public bool destroyAut;
    public PlayerMovement player;

    public int type;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();        
    }

    public void Effect()
    {
        switch (type)
        {
            case 1:
                player.runSpeed += 10;
                break;
            case 2:
                player.jumpForce += 10;
                break;        
            default:                
                break;
        }
    }
}
