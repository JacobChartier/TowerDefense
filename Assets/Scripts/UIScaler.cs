using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
    private TMP_Text label;
    private Slider bar;
    private RectTransform rectTransform;

    private void OnEnable()
    {
        label = GetComponentInChildren<TMP_Text>(true);
        rectTransform = GetComponentInChildren<RectTransform>(true);
        bar = GetComponentInChildren<Slider>(true);
    }

    public void Update()
    {
        rectTransform.sizeDelta = new Vector2(label.GetRenderedValues().x + 20, label.GetRenderedValues().y + 4);
        label.ForceMeshUpdate();

        //if (bar != null)
        //    if (bar.GetComponent<RectTransform>().transform.localPosition.y != -1.5f)
        //        bar.GetComponent<RectTransform>().transform.localPosition = new Vector2(0, -1.5f);
    }
}
