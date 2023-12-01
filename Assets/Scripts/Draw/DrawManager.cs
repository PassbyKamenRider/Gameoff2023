using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawManager : MonoBehaviour
{
    public const float RESOLUTION = 0.1f;
    public static int chosenTool = 0;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject sword;
    private Camera cam;
    [SerializeField] private Line linePrefab;
    [SerializeField] private LayerMask frameMask;
    [SerializeField] private LayerMask lineMask;
    private Line currentLine;
    public ToolHover currentTool;
    private LineRenderer highlightLine;

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, frameMask);
        if (chosenTool == 0 && hit.collider)
        {
            if (Input.GetMouseButtonDown(0))
            {   
                audioPlayerHome.instance.play_audio_draw_home();

                currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);
                if (hit.collider.name == "Character_Frame")
                {
                    currentLine.gameObject.transform.SetParent(player.transform);
                }
                else
                {
                    currentLine.gameObject.transform.SetParent(sword.transform);
                }
            } 
        

            if (Input.GetMouseButton(0))
            {
                if (currentLine)
                {
                    currentLine.SetPosition(mousePos);
                }
            } else {
                if (audioPlayerHome.instance.audio_draw_home.isPlaying) {
                    audioPlayerHome.instance.stop_audio_draw_home();
                }

            }
            
        } else {
            if (audioPlayerHome.instance.audio_draw_home.isPlaying) {
                audioPlayerHome.instance.stop_audio_draw_home();
            }
        }

        RaycastHit2D hit2 = Physics2D.CircleCast(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.5f, Vector2.zero, Mathf.Infinity, lineMask);
        if (chosenTool == 1 && hit2.collider)
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
                audioPlayerHome.instance.play_audio_eraser_home();
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

    public void ToLocalSpace()
    {
        Line[] lines = FindObjectsOfType<Line>();
        foreach (Line line in lines)
        {
            line.TransformToLocalSpcae();
        }
    }

    public void SwitchTool(ToolHover toolSelected)
    {
        currentTool.SwitchDefault();
        currentTool = toolSelected;
        chosenTool = toolSelected.toolType;
        toolSelected.SwitchHover();
    }
}
