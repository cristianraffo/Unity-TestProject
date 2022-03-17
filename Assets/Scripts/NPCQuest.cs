using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCQuest : MonoBehaviour
{
    public GameObject questMarker;
    public PlayerMovement player;
    public GameObject npcPanel;
    public GameObject npcPanel2;
    public GameObject npcPanelQuest;
    public TextMeshProUGUI questText;
    public bool playerClose;
    public bool takeQuest;
    public GameObject[] Gold;
    public int objNumber;
    public GameObject questBtn;

    void Start()
    {
        objNumber = Gold.Length;
        questText.text = "Coins left: " + objNumber;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        questMarker.SetActive(true);
        npcPanel.SetActive(false);        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && takeQuest == false && player.canJump == true)
        {
            Vector3 playerPos = new Vector3(transform.position.x, player.gameObject.transform.position.y, transform.position.z);
            player.gameObject.transform.LookAt(playerPos);

            player.anim.SetFloat("spdX", 0);
            player.anim.SetFloat("spdY", 0);
            player.enabled = false;
            npcPanel.SetActive(false);
            npcPanel2.SetActive(true);
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerClose = true;
            if (takeQuest == false)
            {
                npcPanel.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerClose = false;
            npcPanel.SetActive(false);
            npcPanel2.SetActive(false);
        }
    }

    public void No()
    {
        player.enabled = true;
        npcPanel2.SetActive(false);
        npcPanel.SetActive(true);
    }

    public void Yes()
    {
        player.enabled = true;
        takeQuest = true;
        for (int i = 0; i < Gold.Length; i++)
        {
            Gold[i].SetActive(true);
        }
        playerClose = false;
        questMarker.SetActive(false);
        npcPanel.SetActive(false);
        npcPanel2.SetActive(false);
        npcPanelQuest.SetActive(true);
    }
}
