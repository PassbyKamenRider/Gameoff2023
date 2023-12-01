using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private List<GameObject> textPrinter;
    [SerializeField] private GameObject hint;
    private int dialogueProgress;
    private bool isTriggered;

    private void Update() {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            audioPlayer.instance.play_audio_pick();
            textPrinter[dialogueProgress].SetActive(true);
        }
    }

    public void AddProgress()
    {
        dialogueProgress += 1;
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
