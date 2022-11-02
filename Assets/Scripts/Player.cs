using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float t = 0.1f;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.tag == "StandPoint")
                {
                    //Vector3 a = transform.position;
                    //Vector3 b = hit.transform.position;
                    //transform.position = Vector3.Lerp(a, b, t);
                    //transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, t), speed);
                    transform.position = hit.transform.position;

                }
            }
        }

        //if (Input.GetKeyDown(KeyCode.W))
    }
}
