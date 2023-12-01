using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class InGameDrawManager : MonoBehaviour
{
    public static int chosenTool = 0;
    private Camera cam;
    [SerializeField] private Line linePrefab;
    [SerializeField] private LayerMask lineMask;
    [SerializeField] private LayerMask UIMask;
    [SerializeField] private LayerMask scaleMask;
    [SerializeField] private LayerMask rotateMask;
    private Line currentLine;
    public InGameToolHover currentTool;
    private LineRenderer highlightLine;

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (chosenTool == 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {   
                audioPlayer.instance.play_audio_draw();
                currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);
            }

            if (Input.GetMouseButton(0))
            {
                if (currentLine)
                {
                    currentLine.SetPosition(mousePos);
                }
            } else {
                if (audioPlayer.instance.audio_draw.isPlaying) {
                    audioPlayer.instance.stop_audio_draw();
                }
            }
        } else {
            if (audioPlayer.instance.audio_draw.isPlaying) {
                audioPlayer.instance.stop_audio_draw();
            }
        }

        RaycastHit2D hit2 = Physics2D.CircleCast(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.5f, Vector2.zero, Mathf.Infinity, lineMask);
        if (chosenTool == 1 && hit2.collider && hit2.collider.gameObject.GetComponent<EdgeCollider2D>())
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
                audioPlayer.instance.play_audio_eraser();
   
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

        RaycastHit2D hit3 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, scaleMask);
        if ((chosenTool == 3 || chosenTool == 4) && hit3.collider)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioPlayer.instance.play_audio_zoom();
                if (chosenTool == 4 && hit3.collider.transform.localScale.x > 0.25f)
                {
                    hit3.collider.transform.localScale = hit3.collider.transform.localScale * 0.5f;
                }
                if (chosenTool == 3 && hit3.collider.transform.localScale.y < 1.0f)
                {
                    hit3.collider.transform.localScale = hit3.collider.transform.localScale * 2.0f;
                }
            }
        }

        RaycastHit2D hit4 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, rotateMask);
        if (chosenTool == 2 && hit4.collider)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioPlayer.instance.play_audio_spin();
                hit4.collider.transform.Rotate(new Vector3(0f, 0f, 90f));
            }
        }
    }

    public void SwitchTool(InGameToolHover toolSelected)
    {
        currentTool.SwitchDefault();
        currentTool = toolSelected;
        chosenTool = toolSelected.toolType;
        toolSelected.SwitchHover();
    }
}
