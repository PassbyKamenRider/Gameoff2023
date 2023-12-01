using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class TextPrinter : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] public string[] dialogue;
    [SerializeField] private float timeBetweenChars;
    [SerializeField] private float timeBetweenDialogues;
    [SerializeField] private int itemGiven = -1;
    [SerializeField] private int itemType;
    [SerializeField] private Transform target;
    [SerializeField] private CinemachineVirtualCamera vm;
    private ProgressManager progressManager;
    private ItemManager itemManager;
    private int i = 0;

    private void OnEnable() {
        progressManager = FindObjectOfType<ProgressManager>();
        itemManager = FindObjectOfType<ItemManager>();
        progressManager.SwitchDialogueMode();
        if (target)
        {
            vm.Follow = target;
        }
        EndCheck();
    }

    private void EndCheck() {
        if (i < dialogue.Length)
        {
            text.text = dialogue[i];
            text.maxVisibleCharacters = 0;
            StartCoroutine(TextVisible());
        }
        else
        {
            i = 0;
            if (itemGiven != -1)
            {
                if (itemType == 0)
                {
                    itemManager.GetQuestItem(itemGiven);
                }
                else if (itemType == 1)
                {
                    itemManager.GetCollectable(itemGiven);
                }
                itemGiven = -1;
            }
            if (target)
            {
                vm.Follow = FindObjectOfType<PlayerController>().transform;;
            }
            progressManager.SwitchDialogueMode();
            gameObject.SetActive(false);
        }
    }

    private IEnumerator TextVisible()
    {
        text.ForceMeshUpdate();
        int totalChars = text.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalChars + 1);
            text.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalChars)
            {
                i += 1;
                Invoke("EndCheck", timeBetweenDialogues);
                break;
            }

            counter += 1;
            yield return new WaitForSeconds(timeBetweenChars);
        }
    }
}
