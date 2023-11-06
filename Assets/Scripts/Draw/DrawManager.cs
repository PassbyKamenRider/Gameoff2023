using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public const float RESOLUTION = 0.1f;
    [SerializeField] private GameObject player;
    private Camera cam;
    [SerializeField] private Line linePrefab;
    private Line currentLine;

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);
            currentLine.gameObject.transform.SetParent(player.transform);
        }

        if (Input.GetMouseButton(0))
        {
            currentLine.SetPosition(mousePos);
        }
    }
}
