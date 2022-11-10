using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Player player;

    public float showDistance = 15f;
    
    public float fixedSize = .0003f;

    private RectTransform rectTransform;

    Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = (Camera.main.transform.position - transform.position).magnitude;
        var size = distance * fixedSize * Camera.main.fieldOfView;
        rectTransform.localScale = Vector3.one * size;
        transform.rotation = Camera.main.transform.rotation * originalRotation;
    }
}
