using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] vms;
    private PlayerController playerController;
    private GameObject player;
    private void Start() {
        playerController = FindObjectOfType<PlayerController>(true);
        playerController.enabled = true;
        player = playerController.gameObject;
        player.SetActive(true);
        player.transform.position = new Vector3(0, 20, 0);
        foreach (CinemachineVirtualCamera vm in vms)
        {
            vm.Follow = player.transform;
        }
        // Scale player
        player.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f, 1f);
        Line[] lines = FindObjectsOfType<Line>();
        foreach (Line line in lines)
        {
            line.Scale(0.5f, Vector3.zero);
        }
    }
}
