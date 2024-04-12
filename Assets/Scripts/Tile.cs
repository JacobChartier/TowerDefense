using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private Color darkTileColor = new Color(0.05f, 0.05f, 0.05f, 1.0f);
    private Color lightTileColor = new Color(0.15f, 0.15f, 0.15f, 1.0f);

    public bool isGray, isSelected;

    private void Start()
    {
        if (isGray)
            GetComponent<SpriteRenderer>().color = darkTileColor;
        else
            GetComponent<SpriteRenderer>().color = lightTileColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
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

        if (eventData.button == PointerEventData.InputButton.Right)
            if (isSelected)
                GetComponent<SpriteRenderer>().color = Color.magenta;

        if (eventData.button == PointerEventData.InputButton.Left)
            if (isSelected)
                GetComponent<SpriteRenderer>().color = Color.yellow;

        if (!isSelected)
            GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
