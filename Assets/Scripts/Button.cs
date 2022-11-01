using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Player player;

    private Image image;

    public float FixedSize = .0003f;

    private RectTransform rectTransform;

    Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = (Camera.main.transform.position - transform.position).magnitude;
        var size = distance * FixedSize * Camera.main.fieldOfView;
        rectTransform.localScale = Vector3.one * size;
        transform.rotation = Camera.main.transform.rotation * originalRotation;

        // hide the StandPoint if player has the same x and z value
        if (this.gameObject.transform.position.x == player.gameObject.transform.position.x && this.gameObject.transform.position.z == player.gameObject.transform.position.z)
        {
            image.enabled = false;
        }
        if (this.gameObject.transform.position.x != player.gameObject.transform.position.x || this.gameObject.transform.position.z != player.gameObject.transform.position.z)
        {
            image.enabled = true;
        }
    }
}
