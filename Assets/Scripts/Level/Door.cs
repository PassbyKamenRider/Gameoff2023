using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private int requiredItem;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private GameObject hint;
    private GameObject player;
    private ItemManager itemManager;
    private bool isTriggered;

    private void Start() {
        player = FindObjectOfType<PlayerController>(true).gameObject;
        itemManager = FindObjectOfType<ItemManager>(true);
    }

    private void Update() {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if (requiredItem == -1 || itemManager.hasQuestItems[requiredItem])
            {
                player.transform.position = targetPosition;
            }
            else
            {
                Debug.Log("Locked");
            }
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
