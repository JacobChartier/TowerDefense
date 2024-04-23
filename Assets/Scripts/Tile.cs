using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public int X { get; internal set; }
    public int Y { get; internal set; }

    private Color darkTileColor = new Color(0.05f, 0.05f, 0.05f, 1.0f);
    private Color lightTileColor = new Color(0.15f, 0.15f, 0.15f, 1.0f);
    private Color lightPathTileColor = new Color(1.0f, 1.0f, 0.4f, 1.0f);
    private Color darkPathTileColor = new Color(0.8f, 0.8f, 0.3f, 1.0f);

    public bool isGray, isSelected, isPath;

    private Sprite wallSprite;

    private void Start()
    {
        wallSprite = Resources.Load<Sprite>("Sprites/Wall");

        if (isGray)
            GetComponent<SpriteRenderer>().color = darkTileColor;
        else
            GetComponent<SpriteRenderer>().color = lightTileColor;
    }

    private void Update()
    {
        if (isPath)
        {
            if (isGray)
                GetComponent<SpriteRenderer>().color = darkPathTileColor;
            else
                GetComponent<SpriteRenderer>().color = lightPathTileColor;
        }
    }

    internal void SetPath(bool isPath)
    {
        this.isPath = isPath;

        if (isPath)
        {
            if (isGray)
                GetComponent<SpriteRenderer>().color = darkPathTileColor;
            else
                GetComponent<SpriteRenderer>().color = lightPathTileColor;
        }
        else
        {
            if (isGray)
                GetComponent<SpriteRenderer>().color = darkTileColor;
            else
                GetComponent<SpriteRenderer>().color = lightTileColor;
        }
    }

    private void Reset()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/default_tile");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.TargetTile = this;

        if (isSelected) return;
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSelected) return;

        if (isGray)
            GetComponent<SpriteRenderer>().color = darkTileColor;
        else
            GetComponent<SpriteRenderer>().color = lightTileColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isSelected = !isSelected;

        Reset();

        if (eventData.button == PointerEventData.InputButton.Right)
            if (isSelected)
                GetComponent<SpriteRenderer>().color = Color.magenta;

        if (eventData.button == PointerEventData.InputButton.Left)
            if (isSelected)
            {
                GetComponent<SpriteRenderer>().sprite = wallSprite;
                GetComponent<SpriteRenderer>().color = Color.white;
            }

        if (!isSelected)
            GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
