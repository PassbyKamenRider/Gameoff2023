using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraConfiner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
    }
}
