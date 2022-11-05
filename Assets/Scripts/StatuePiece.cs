using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePiece : MonoBehaviour
{
    public float speed = 0.6f;

    public Transform destination;

    private Vector3 originalPosition;

    private Quaternion originalRotation;

    private bool isPickedUp = false;

    private bool isFloating = false;

    private bool isGettingBack = false;

    public Vector3 velocity = Vector3.zero;

    private IEnumerator Floating()
    {
        yield return new WaitForSeconds(2);

        GetBack();
    }

    private IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(10);

        Destroy(this);
    }

    public bool PickedUP()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;
            isFloating = true;
            StartCoroutine(Floating());
            return true;
        }

        return false;
    }

    public bool GetBack()
    {
        isFloating = false;
        isGettingBack = true;
        StartCoroutine(StopMoving());
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFloating)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination.position, ref velocity, speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, destination.rotation, 2f * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, destination.localScale, 2f * Time.deltaTime);
        }

        if (isGettingBack)
        {
            transform.position = Vector3.SmoothDamp(transform.position, originalPosition, ref velocity, speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, 2f * Time.deltaTime);
        }
    }
}
