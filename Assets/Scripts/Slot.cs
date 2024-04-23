using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    public bool isSelected = false;

    private void Start()
    {
        if (isSelected)
            GetComponent<Outline>().enabled = true;
        else
            ResetOutline();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isSelected = !isSelected;

        if (isSelected)
            GetComponent<Outline>().enabled = true; 
        else 
            ResetOutline();
    }

    public void ResetOutline()
    {
        GetComponent<Outline>().enabled = false;
    }
}
