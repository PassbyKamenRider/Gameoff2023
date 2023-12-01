using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool[] hasQuestItems;
    public bool[] hasCollectables;
    [SerializeField] private List<Vector3> questItemPositions;
    [SerializeField] private GameObject questItemParent;
    [SerializeField] private List<GameObject> questItemPrefabs;
    [SerializeField] private GameObject[] collectables;
    private int currentQuestItem;
    private ProgressManager progressManager;
    private void Start() {
        hasQuestItems = new bool[8];
        hasCollectables = new bool[9];
        progressManager = FindObjectOfType<ProgressManager>();
    }
    public void GetQuestItem(int itemId)
    {
        GameObject obj = Instantiate(questItemPrefabs[itemId]);
        obj.transform.SetParent(questItemParent.transform);
        obj.transform.localScale = new Vector3(0.3f, 0.3f, 1f);
        obj.transform.localPosition = questItemPositions[currentQuestItem];
        hasQuestItems[currentQuestItem] = true;
        currentQuestItem += 1;

        switch(itemId)
        {
            case 0:
            progressManager.GetPills();
            break;

            default:
            break;
        }
    }

    public void GetCollectable(int itemId)
    {
        collectables[itemId].SetActive(true);

        switch(itemId)
        {
            case 0:
            progressManager.GetDiary();
            break;

            default:
            break;
        }
    }

    public void GetTool()
    {
        progressManager.GetTool();
    }

    public bool hasItem(int itemId, int itemType)
    {
        switch(itemType)
        {
            case 0:
            return hasQuestItems[itemId];

            case 1:
            return hasCollectables[itemId];

            default:
            return false;
        }
    }
}
