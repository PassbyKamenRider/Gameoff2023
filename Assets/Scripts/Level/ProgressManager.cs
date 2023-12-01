using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ProgressManager : MonoBehaviour
{
    [Header("Start Progress Control")]
    [SerializeField] CinemachineVirtualCamera[] vms;
    [SerializeField] private InGameDrawManager drawManager;
    private PlayerController playerController;
    private GameObject player;
    private void Start() {
        playerController = FindObjectOfType<PlayerController>(true);
        playerController.enabled = true;
        player = playerController.gameObject;
        player.SetActive(true);
        player.transform.position = new Vector3(0, 10, 0);
        foreach (CinemachineVirtualCamera vm in vms)
        {
            vm.Follow = player.transform;
        }
        // Scale player
        player.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        player.GetComponent<Animator>().enabled = false;

        // Move Sword
        GameObject sword = GameObject.FindGameObjectWithTag("Sword");
        sword.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f, 1f);
        sword.transform.localPosition = new Vector3(-4.5f, 2.5f, 0f);
        sword.transform.eulerAngles = new Vector3(0f, 0f, -30f);
        sword.GetComponent<Animator>().Play("Sword_Idle");
        sword.transform.SetParent(player.transform.GetChild(0));
        sword.transform.localPosition = new Vector3(0.3f, -0.5f, 0f);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GetTool();
        }
    }

    [Header("1_Get Tool Progress Control")]
    [SerializeField] private PolygonCollider2D bedrooom2Collider;
    [SerializeField] private GameObject dialogue1;
    [SerializeField] private Animator canvasAnimator;
    [SerializeField] private GameObject tools;
    [SerializeField] private InGameDrawManager inGameDrawManager;
    public void GetTool()
    {
        inGameDrawManager.enabled = true;
        bedrooom2Collider.isTrigger = true;
        tools.SetActive(true);
        dialogue1.SetActive(true);
    }

    [Header("2_Get Diary Progress Control")]
    [SerializeField] private GameObject dialogue2;
    public void GetDiary()
    {
        dialogue2.SetActive(true);
    }

    [Header("3_Get Pills")]
    [SerializeField] private Dialogue momDialogue;
    //[SerializeField] private ItemManager itemManager;
    public void GetPills()
    {
        momDialogue.AddProgress();
        //itemManager.GetQuestItem(1);
    }

    public void SwitchDialogueMode()
    {
        canvasAnimator.SetBool("Switch", !canvasAnimator.GetBool("Switch"));
        drawManager.enabled = !drawManager.enabled;
        playerController.Stop();
        player.GetComponent<Animator>().Play("Idle");
        playerController.enabled = !playerController.enabled;
    }
}
