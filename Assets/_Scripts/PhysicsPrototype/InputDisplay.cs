using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class InputDisplay : MonoBehaviour
{
    public GameObject entryPoint;
    public GameObject exitPoint;

    public LineRenderer lineRenderer;

    void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();
        UpdateInputDisplay();

    }

    void OnDisable()
    {
        lineRenderer = null;
    }

    private void Update()
    {
        UpdateInputDisplay();
    }

    void UpdateInputDisplay()
    {
        lineRenderer.SetPosition(0, entryPoint.transform.position);
        lineRenderer.SetPosition(1, exitPoint.transform.position);
    }
}
