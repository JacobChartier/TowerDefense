using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNode : MonoBehaviour
{
    [SerializeField] private SkillNode parentNode;
    [SerializeField] private LineRenderer lineRenderer;

    private void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (parentNode != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, parentNode.transform.position);
            lineRenderer.SetPosition(2, parentNode.parentNode.transform.position);
        }
    }
}
