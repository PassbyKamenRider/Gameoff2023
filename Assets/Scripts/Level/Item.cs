using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int itemId;
    [SerializeField] private int itemType;
    [SerializeField] private GameObject hint;
    private bool isObtained;
    private bool isTriggered;
    private ItemManager itemManager;

    private void Start() {
        itemManager = FindObjectOfType<ItemManager>();
    }

    private void Update() {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if (itemType == 0)
            {
                itemManager.GetQuestItem(itemId);
            }
            else if (itemType == 1)
            {
                itemManager.GetCollectable(itemId);
            }
            else
            {
                itemManager.GetTool();
            }
            audioPlayer.instance.play_audio_pick();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            hint.SetActive(true);
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            hint.SetActive(false);
            isTriggered = false;
        }
    }
}
