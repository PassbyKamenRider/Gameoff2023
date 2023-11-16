using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private EdgeCollider2D edgeCollider;

    private readonly List<Vector2> points = new List<Vector2>();

    private void Start() {
        edgeCollider.transform.position -= transform.position;
        lineRenderer.sortingLayerName = "Line";
        lineRenderer.sortingOrder = 1;
    }

    // private void Update() {
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         TransformToLocalSpcae();
    //     }
    // }

    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos))
        {
            return;
        }

        points.Add(pos);

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);

        edgeCollider.points = points.ToArray();
    }

    private bool CanAppend(Vector2 pos)
    {
        if (lineRenderer.positionCount == 0)
        {
            return true;
        }

        return Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }

    public void TransformToLocalSpcae()
    {
        Vector3[] linePoints = new Vector3[lineRenderer.positionCount];
		lineRenderer.GetPositions(linePoints);
        for (int i = 0; i < linePoints.Length; i++)
        {
            linePoints[i] = lineRenderer.transform.InverseTransformPoint(linePoints[i]);
        }
        lineRenderer.SetPositions(linePoints);
        lineRenderer.useWorldSpace = false;
    }
}
