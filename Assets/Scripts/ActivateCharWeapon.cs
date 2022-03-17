using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCharWeapon : MonoBehaviour
{
    public PickupWeapons pickWeapons;
    public int weaponNum;

    void Start()
    {
        pickWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PickupWeapons>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickWeapons.ActivateWeapons(weaponNum);
            Destroy(gameObject);
        }
    }
}
