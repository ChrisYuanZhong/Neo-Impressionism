using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 1f;

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
            transform.position = Vector3.MoveTowards(transform.position, destination.position, 10f * Time.deltaTime);
            if(transform.position.x == destination.position.x && transform.position.z == destination.position.z)
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
