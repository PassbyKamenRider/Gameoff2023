using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEvent : MonoBehaviour
{
    [SerializeField] private Transform dusts;
    [SerializeField] private BoxCollider2D ticketCollider;

    private void Update() {
        if (dusts.childCount == 0)
        {
            ticketCollider.enabled = true;
            enabled = false;
        }
    }
}
