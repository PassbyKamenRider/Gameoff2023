using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CatEventController : MonoBehaviour
{
    [SerializeField] private Transform dusts;
    [SerializeField] private Animator catAnimator;
    [SerializeField] private CinemachineVirtualCamera vm;
    [SerializeField] private Transform cat;
    private Transform player;

    private void Start() {
        player = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    private void Update() {
        if (dusts.childCount == 0)
        {
            catAnimator.Play("Cat_Out");
            vm.Follow = cat;
            Invoke("FollowPlayer", 4.0f);
            enabled = false;
        }
    }

    private void FollowPlayer()
    {
        vm.Follow = player;
    }
}
