using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public int hp;
    public int weaponDmg;
    public int handDmg;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weaponImpact")
        {
            if (anim != null)
            {
                anim.Play("dummy");
            }
            hp -= weaponDmg;
        }

        if (other.gameObject.tag == "handImpact")
        {
            if (anim != null)
            {
                anim.Play("dummy");
            }
            hp -= handDmg;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
