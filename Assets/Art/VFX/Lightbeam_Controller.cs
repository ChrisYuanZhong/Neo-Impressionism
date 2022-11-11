using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightbeam_Controller : MonoBehaviour
{
    public bool on;
    public ParticleSystem sparkle;
    public float duration;
    private float blend = 0f;
    // Start is called before the first frame update
    void Start()
    {
        sparkle.Stop();
        this.transform.localScale = new Vector3(blend, blend, blend);
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            sparkle.Play();
           // sparkle.enableEmission = true;
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1, 1, 1), 8f * Time.deltaTime);

           
        }
        if (!on)
        {
            
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0, 0, 0), 20f * Time.deltaTime);
            // sparkle.enableEmission = false;
            sparkle.Stop();
            
        }
    }


        
        
    
}
