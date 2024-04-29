using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillNode : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private SkillNode parentNode;

    public NodeState state;
    public List<SkillNode> children = new();

    [SerializeField] private int healthBonus;

    private void Awake()
    {
        if (parentNode != null)
        parentNode.children.Add(this);
    }

    private void Start()
    {
        if (parentNode == null) 
            SetState(NodeState.UNLOCKED);
    }

    private void SetState(NodeState value)
    {
        state = value;

        switch (state)
        {
            case NodeState.OBTAINED:
                this.GetComponentInChildren<UnityEngine.UI.Image>().color = new Color(0.035014f, 0.2830189f, 0.0f, 1.0f);

                foreach (var child in children)
                    child.SetState(NodeState.UNLOCKED);

                break;

            case NodeState.UNLOCKED:
                this.GetComponentInChildren<UnityEngine.UI.Image>().color = new Color(0.03921569f, 0.03921569f, 0.03921569f, 1.0f);

                foreach (var child in children)
                    child.SetState(NodeState.LOCKED);

                break;

            case NodeState.LOCKED:
                this.GetComponentInChildren<UnityEngine.UI.Image>().color = new Color(0.2830189f, 0.0f, 0.0f, 1.0f);

                foreach (var child in children)
                    child.SetState(NodeState.LOCKED);

                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && this.state == NodeState.UNLOCKED)
        {
            Player.Instance.Health = new(Player.Instance.Health.Current + healthBonus, Player.Instance.Health.Current + healthBonus);
            GameManager.Instance.HealthBonus += healthBonus;
            SetState(NodeState.OBTAINED);
        }
    }
}

public enum NodeState
{
    OBTAINED,
    UNLOCKED,
    LOCKED
}
