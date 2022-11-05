using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float speed = 0.6f;

    public Transform destination;

    private bool isPickedUp = false;

    public Vector3 velocity = Vector3.zero;

    private IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(10);

        Destroy(this);
    }

    public void PickedUP()
    {
        isPickedUp = true;
        StartCoroutine(StopMoving());
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
