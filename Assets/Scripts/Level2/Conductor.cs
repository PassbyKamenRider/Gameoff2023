using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private GameObject wall;
    private ItemManager itemManager;
    private Transform player;

    private void Start() {
        itemManager = FindObjectOfType<ItemManager>();
        player = FindObjectOfType<PlayerController>(true).transform;
    }
    private void Update() {
        if (player.localScale.x >= 1.0f && itemManager.hasQuestItems[3] && itemManager.hasQuestItems[4])
        {
            dialogue.dialogueProgress = 2;
            wall.SetActive(false);
        }
        else if (itemManager.hasQuestItems[3] && itemManager.hasQuestItems[4])
        {
            dialogue.dialogueProgress = 1;
        }
        else
        {
            dialogue.dialogueProgress = 0;
        }
    }
}
