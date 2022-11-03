using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    public float speed = 0.8f;

    public Vector3 velocity = Vector3.zero;

    public bool move = false;

    private Transform destination;

    GameObject[] POI;

    // Start is called before the first frame update
    void Start()
    {
        POI = GameObject.FindGameObjectsWithTag("StandPoint");
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
                    destination = hit.transform;
                    move = true;
                    foreach(GameObject go in POI)
                    {
                        go.SetActive(false);
                    }

                }
            }
        }

        if (move == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination.position, ref velocity, speed);
            //transform.position = Vector3.Lerp(transform.position, destination.position, 2 * Time.deltaTime);
            //transform.position = Vector3.MoveTowards(transform.position, destination.position, 10f * Time.deltaTime);
            //if ((float)System.Math.Round(transform.position.x, 1) == (float)System.Math.Round(destination.position.x, 1) && (float)System.Math.Round(transform.position.z, 1) == (float)System.Math.Round(destination.position.z, 1))
            if ((int)transform.position.x == (int)destination.position.x && (int)transform.position.z == (int)destination.position.z)
            {
                move = false;
                foreach (GameObject go in POI)
                {
                    go.SetActive(true);
                }
            }
        }
    }
}
