using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    public float speed = 0.8f;
    public GameObject fade;
    public int collectedPieces = 0;

    private Vector3 velocity = Vector3.zero;

    private bool move = false;

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
                if (hit.transform.gameObject.CompareTag("StandPoint"))
                {
                    destination = hit.transform;
                    move = true;
                    foreach(GameObject go in POI)
                    {
                        go.SetActive(false);
                    }

                }

                if (hit.transform.gameObject.CompareTag("Glasses"))
                {
                    if (hit.transform.gameObject.GetComponent<Pickup>().PickedUP() == true)
                    {
                        collectedPieces++;
                    }
                }

                if (hit.transform.gameObject.name == "Glasses Case")
                {
                    if (collectedPieces == 3)
                    {
                        // Collect the Glasses
                        Destroy(hit.transform.gameObject);
                    }
                }

                if (hit.transform.gameObject.name == "Statue Piece")
                {
                    if (hit.transform.gameObject.GetComponent<StatuePiece>().PickedUP() == true)
                    {
                        // Collect the Lever
                    }
                }

                if (hit.transform.gameObject.name == "Lever Base")
                {
                    fade.GetComponent<Fade>().FadeShow();
                    print("1");

                }
            }
        }

        if (move == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination.position, ref velocity, speed);
            //transform.position = Vector3.Lerp(transform.position, destination.position, 2 * Time.deltaTime);
            //transform.position = Vector3.MoveTowards(transform.position, destination.position, 10f * Time.deltaTime);
            
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
