using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightbeam_Controller : MonoBehaviour
{
    public bool on;
    public ParticleSystem sparkle;
    static float t = 0f;
    static float duration = 1f;
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
            StartCoroutine(LerpBlend());
        }
        if (!on)
        {
            StartCoroutine(LerpBlend());
        }
    }

    IEnumerator LerpBlend()
    {
        t = 0;
        if (on)
        {
            
            while (blend < 1)
            {
                blend = Mathf.Lerp(0, 1, t / duration);
                t += Time.deltaTime;
                this.transform.localScale = new Vector3(blend, blend, blend);
                yield return null; 
            }
            sparkle.Play();
        }
        else
        {
            while (blend > 0)
            {
                blend = Mathf.Lerp(1, 0, t / duration);
                t += Time.deltaTime;
                this.transform.localScale = new Vector3(blend, blend, blend);
                yield return null;
            }
            sparkle.Stop();

        }
        
        
    }
}
