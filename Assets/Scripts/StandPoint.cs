using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StandPoint : MonoBehaviour
{
    public Player player;

    // Update is called once per frame
    void Update()
    {
        // hide the StandPoint if player has the same x and z value
        if (this.gameObject.transform.position.x == player.gameObject.transform.position.x && this.gameObject.transform.position.z == player.gameObject.transform.position.z)
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (this.gameObject.transform.position.x != player.gameObject.transform.position.x || this.gameObject.transform.position.z != player.gameObject.transform.position.z)
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }*/
}
