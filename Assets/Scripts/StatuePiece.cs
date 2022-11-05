using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePiece : MonoBehaviour
{
    public float speed = 0.6f;

    public Transform destination;

    private Transform originalTransform;

    private bool isPickedUp = false;

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
            StartCoroutine(Floating());
            return true;
        }

        return false;
    }

    public bool GetBack()
    {
        isPickedUp = false;
        isGettingBack = true;
        StartCoroutine(StopMoving());
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination.position, ref velocity, speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, destination.rotation, 2f * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, destination.localScale, 2f * Time.deltaTime);
            /*transform.position = Vector3.Lerp(transform.position, destination.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, destination.rotation, speed * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, destination.localScale, speed * Time.deltaTime);*/

            /*transform.position = destination.position;
            transform.rotation = destination.rotation;
            transform.localScale = destination.localScale;
            Destroy(this);*/
        }

        if (isGettingBack)
        {
            transform.position = Vector3.SmoothDamp(transform.position, originalTransform.position, ref velocity, speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, originalTransform.rotation, 2f * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, originalTransform.localScale, 2f * Time.deltaTime);
        }
    }
}
