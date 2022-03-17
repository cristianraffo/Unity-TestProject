using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapons : MonoBehaviour
{
    public BoxCollider[] weaponBoxCol;
    public BoxCollider handBoxCol;

    public GameObject[] weapons;
    public PlayerMovement player;

    void Start()
    {
        DeactivateWeaponColliders();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            DeactivateWeapons();
        }
    }

    public void ActivateWeapons(int n)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[n].SetActive(true);

        player.hasWeapon = true;
    }

    public void DeactivateWeapons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        player.hasWeapon = false;
    }

    public void ActivateWeaponColliders()
    {
        for (int i = 0; i < weaponBoxCol.Length; i++)
        {
            if (player.hasWeapon)
            {
                if (weaponBoxCol[i] != null)
                {
                    weaponBoxCol[i].enabled = true;
                }
            }
            else
            {
                handBoxCol.enabled = true;
            }
        }
    }

    public void DeactivateWeaponColliders()
    {
        for (int i = 0; i < weaponBoxCol.Length; i++)
        {
            if (weaponBoxCol[i] != null)
            {
                weaponBoxCol[i].enabled = false;
            }
        }
        handBoxCol.enabled = false;
    }
}
