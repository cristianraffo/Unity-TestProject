using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "objeto" && hitInfo.collider.gameObject.GetComponent<Potion>().destroyMouse == true)
                {
                    hitInfo.collider.gameObject.GetComponent<Potion>().Effect();
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Potion" && other.GetComponent<Potion>().destroyAut == true)
        {
            other.GetComponent<Potion>().Effect();
            Destroy(other.gameObject);
        }

        if (other.tag == "Potion")
        {
            if (Input.GetMouseButtonDown(1) && other.GetComponent<Potion>().destroyMouse == false)
            {
                other.GetComponent<Potion>().Effect();
                Destroy(other.gameObject);
            }
        }
    }
}
