using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TransformToLocalSpcae();
        }
    }

    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos))
        {
            return;
        }

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
    }

    private bool CanAppend(Vector2 pos)
    {
        if (lineRenderer.positionCount == 0)
        {
            return true;
        }

        return Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }

    private void TransformToLocalSpcae()
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
