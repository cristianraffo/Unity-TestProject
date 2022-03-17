using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{
    public NPCQuest npcQuest;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            npcQuest.objNumber--;
            npcQuest.questText.text = "Coins left: " + npcQuest.objNumber;
            if (npcQuest.objNumber <= 0)
            {
                npcQuest.questText.text = "Quest completed";
                npcQuest.questBtn.SetActive(true);
                Invoke("Reload", 8.0f);
            }
            transform.parent.gameObject.SetActive(false);            
        }
    }

    void Reload()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
