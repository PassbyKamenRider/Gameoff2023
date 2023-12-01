using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    private GameObject player;

    private void Start() {
        player = FindObjectOfType<PlayerController>(true).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            player.transform.position = new Vector3(0f, -55f, 0f);
            dialogue.SetActive(true);
        }
    }
}
