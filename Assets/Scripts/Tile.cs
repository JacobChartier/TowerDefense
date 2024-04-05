using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public bool isGray, isSelected;

    private void Start()
    {
        if (isGray)
            GetComponent<SpriteRenderer>().color = Color.black;
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
            GetComponent<SpriteRenderer>().color = Color.black;
        else
            GetComponent<SpriteRenderer>().color = Color.white;
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
