using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Camera cam;
    public bool playScene = false;
    public Material skybox;

    static float t = 0f;
    static float duration = 6000f;
    private float blend = 0f;
    private Light sunlight;
    public Material[] mats;


    // Start is called before the first frame update
    void Start()
    {
        skybox.SetFloat("_NightLerp", 0);
        sunlight = GetComponent<Light>();
        sunlight.color = new Color(207, 207, 207, 255);
    }

    private void OnApplicationQuit()
    {
        sunlight.color = new Color(207, 207, 207, 255);
        skybox.SetFloat("_NightLerp", 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (playScene)
        {
            Destroy(cam.GetComponent<MouseLook>());
            StartCoroutine(FadeNight());
            Quaternion target = Quaternion.Euler(-20, 0, 0);
            cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, target, 8f * Time.deltaTime);
            


        }
    }

  

    IEnumerator FadeNight()
    {
        while (blend < 1)
        {
            if (blend == .5)
            {
                sunlight.color = new Color(97, 111, 253, 255);
            }
            
            blend = Mathf.Lerp(0, 1, t / duration);
            t += Time.deltaTime;
            skybox.SetFloat("_NightLerp", blend);
            foreach (Material mat in mats)
            {

                mat.SetFloat("_Color_blindness", blend);
            }

            yield return null;
        }


    }
}
