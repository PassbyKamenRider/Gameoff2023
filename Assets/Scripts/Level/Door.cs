using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private int requiredItem;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject lockedDialogue;
    [SerializeField] private GameObject bossfight;
    private GameObject player;
    private ItemManager itemManager;
    private bool isTriggered;
    [SerializeField] private bool isElevator;

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
                if (isElevator)
                {
                    player.GetComponent<PlayerController>().enabled = false;
                    player.transform.position = new Vector3(10f, -150.1f, 0f);
                    player.GetComponent<Rigidbody2D>().gravityScale = 0;
                    BossFightController bc = player.AddComponent<BossFightController>();
                    bc.playerY = new List<float>(){-150f, -151.5f, -153f};
                    bossfight.SetActive(true);
                }
            }
            else
            {
                lockedDialogue.SetActive(true);
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
