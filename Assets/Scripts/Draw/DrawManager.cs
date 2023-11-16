using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawManager : MonoBehaviour
{
    public const float RESOLUTION = 0.1f;
    public static int chosenTool = 0;
    [SerializeField] private GameObject player;
    private Camera cam;
    [SerializeField] private Line[] linePrefabs;
    private int chosenLine = 0;
    [SerializeField] private string frameMask;
    [SerializeField] private string lineMask;
    private Line currentLine;
    public ToolHover currentTool;
    private LineRenderer highlightLine;

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, LayerMask.GetMask(frameMask));
        if (chosenTool <= 2 && hit.collider)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentLine = Instantiate(linePrefabs[chosenLine], mousePos, Quaternion.identity);
                currentLine.gameObject.transform.SetParent(player.transform);
            }

            if (Input.GetMouseButton(0))
            {
                if (currentLine)
                {
                    currentLine.SetPosition(mousePos);
                }
            }
        }

        RaycastHit2D hit2 = Physics2D.CircleCast(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.5f, Vector2.zero, Mathf.Infinity, LayerMask.GetMask(lineMask));
        if (chosenTool == 3 && hit2.collider)
        {
            if (highlightLine)
            {
                highlightLine.startColor = Color.black;
                highlightLine.endColor = Color.black;
            }
            LineRenderer lr = hit2.collider.transform.parent.GetComponent<LineRenderer>();
            highlightLine = lr;
            lr.startColor = Color.red;
            lr.endColor = Color.red;

            if (Input.GetMouseButtonDown(0))
            {
                Destroy(highlightLine.transform.GetChild(0).gameObject);
                Destroy(highlightLine.gameObject);
                highlightLine = null;
            }
        }
        else
        {
            if (highlightLine)
            {
                highlightLine.startColor = Color.black;
                highlightLine.endColor = Color.black;
            }
        }
    }

    public void TestPlayerWalk(Rigidbody2D playerRb)
    {
        Line[] lines = FindObjectsOfType<Line>();
        foreach (Line line in lines)
        {
            line.TransformToLocalSpcae();
        }
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void SwitchLine(int lineType)
    {
        chosenLine = lineType;
    }

    public void SwitchTool(ToolHover toolSelected)
    {
        currentTool.SwitchDefault();
        currentTool = toolSelected;
        chosenTool = toolSelected.toolType;
        toolSelected.SwitchHover();

        if (chosenTool <= 2)
        {
            chosenLine = chosenTool;
        }
    }
}
