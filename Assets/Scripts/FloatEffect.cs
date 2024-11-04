using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float startX = 0f;
    public float startY = 0f;
    private float duration = 1f;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startY = rectTransform.anchoredPosition.y;

    }

    // Update is called once per frame
    void Update()
    {
       var newY = startY + (startY + Mathf.Cos(Time.time * duration * 2)) / .1f;

        rectTransform.anchoredPosition = new Vector2(startX, newY);
    }
}
