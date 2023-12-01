using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    [SerializeField] private Transform pills;
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private Animator animator;
    private SpriteRenderer sprite;
    private bool isTriggered;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        if (transform.rotation.eulerAngles.z == 90f)
        {
            animator.gameObject.SetActive(true);
            animator.Play("Pills_Out");
            gameObject.layer = 0;
            enabled = false;
        }
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            dialogue.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            isTriggered = true;
            hint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            isTriggered = false;
            hint.SetActive(false);
        }    
    }
}
