using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{

    Vector3 previewStartPoint;
    Vector3 previewEndPoint;


    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    public void StartPoint(Vector3 startPoint)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);

        lineRenderer.enabled = true;
        previewStartPoint = startPoint;
        lineRenderer.SetPosition(0, previewStartPoint);
    }

    public void EndPoint(Vector3 endPoint)
    {
        lineRenderer.enabled = true;
        previewEndPoint = endPoint;
        lineRenderer.SetPosition(1, previewEndPoint);

    }
    public void Launched()
    {
     

        lineRenderer.enabled = false;
    }
    private void Update()
    {


    }
}
