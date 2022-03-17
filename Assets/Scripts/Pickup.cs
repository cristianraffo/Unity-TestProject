using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pickup : MonoBehaviour
{
    public int objNumber;
    public TextMeshProUGUI questText;
    public GameObject missionBtn;

    void Start()
    {
        objNumber = GameObject.FindGameObjectsWithTag("Gold").Length;
        questText.text = "Coins left: " + objNumber;        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Gold")
        {
            Destroy(col.transform.parent.gameObject);
            objNumber--;
            questText.text = "Coins left: " + objNumber;

            if (objNumber <= 0)
            {
                questText.text = "Quest complete";
                missionBtn.SetActive(true);
            }
        }
    }
}
