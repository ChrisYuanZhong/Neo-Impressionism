using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandPointButton : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;

    private RectTransform rectTransform;
    private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        var screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPoint;

        //var viewportPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        //var distanceFromCenter = Vector2.Distance(viewportPoint, Vector2.one * 0.5f);

        //var show = distanceFromCenter < 0.3f;

        //image.enabled = true;
    }
}
