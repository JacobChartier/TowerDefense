using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNode : MonoBehaviour
{
    [SerializeField] private SkillNode parentNode;
    [SerializeField] private LineRenderer lineRenderer;

    public NodeState state;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (parentNode != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, parentNode.transform.position);
        }

        SetState();

        switch (this.state)
        {
            case NodeState.OBTAINED:
                this.GetComponentInChildren<SpriteRenderer>().color = new Color(0.035014f, 0.2830189f, 0.0f, 1.0f);
                break;

            case NodeState.UNLOCKED:
                this.GetComponentInChildren<SpriteRenderer>().color = new Color(0.03921569f, 0.03921569f, 0.03921569f, 1.0f);
                break;

            case NodeState.LOCKED:
                this.GetComponentInChildren<SpriteRenderer>().color = new Color(0.2830189f, 0.0f, 0.0f, 1.0f);
                break;
        }
    }

    private void SetState()
    {
        switch (parentNode.state)
        {
            case NodeState.OBTAINED:
                state = NodeState.UNLOCKED;

                lineRenderer.startColor = new Color(0.2f, 0.2f, 0.2f, 1.0f);
                lineRenderer.endColor = new Color(0.3f, 0.3f, 0.3f, 1.0f);

                break;

            case NodeState.UNLOCKED:
                state = NodeState.LOCKED;

                lineRenderer.startColor = new Color(0.3113208f, 0.0f, 0.0f, 1.0f);
                lineRenderer.endColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);

                break;

            case NodeState.LOCKED:
                state = NodeState.LOCKED;

                lineRenderer.startColor = new Color(0.3113208f, 0.0f, 0.0f, 1.0f);
                lineRenderer.endColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);

                break;
        }
    }
}

public enum NodeState
{
    OBTAINED, 
    UNLOCKED, 
    LOCKED
}
