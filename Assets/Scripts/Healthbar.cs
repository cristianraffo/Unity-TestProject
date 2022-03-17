using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public int maxHealth;
    public float currentHealth;
    public Image healthbarImg;

    void Start()
    {
     currentHealth = maxHealth; 
    }

    void Update()
    {
        CheckHeal();
        
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void CheckHeal()
    {
        healthbarImg.fillAmount = currentHealth / maxHealth;
    }       

}
