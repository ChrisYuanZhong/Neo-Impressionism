using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlind_Controller : MonoBehaviour
{
    public Material[] mats;
    public bool colorblind;

    static float t = 0f;
    static float duration = 1f;
    private float blend = 0f;
 
    // Start is called before the first frame update
    void Start()
    {
        colorblind = false;
        foreach (Material mat in mats)
        {
            mat.SetFloat("_Color_blindness", 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (colorblind)
        {
            StartCoroutine(LerpBlend());
            
        }if (!colorblind)
        {
            StartCoroutine(LerpBlend());
        }
       
    }

    IEnumerator LerpBlend()
    {
        t = 0;
        if (colorblind)
        {
            while (blend < 1)
            {
                blend = Mathf.Lerp(0, 1, t / duration);
                t += Time.deltaTime;
                foreach (Material mat in mats)
                {

                    mat.SetFloat("_Color_blindness", blend);
                }
                yield return null;
            }
        }
        else
        {
            while (blend > 0)
            {
                blend = Mathf.Lerp(1, 0, t / duration);
                t += Time.deltaTime;
                foreach (Material mat in mats)
                {

                    mat.SetFloat("_Color_blindness", blend);
                }
                yield return null;
            }

        }
        
        
    }
}
