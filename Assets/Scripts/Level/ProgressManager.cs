using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private PlayerController playerController;
    private GameObject player;
    private void Start() {
        playerController = FindObjectOfType<PlayerController>(true);
        player = playerController.gameObject;
        player.SetActive(true);
        player.transform.position = new Vector3(0, 20, 0);
    }
}
