using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Camera cam;
    public bool playScene = false;

    static float t = 0f;
    static float duration = 500f;
    private float blendY = 0f;
    private float blendX = 0f;


    private float StartY;
    private float EndY;
    private float StartX;
    private float EndX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playScene)
        {
            //Destroy(cam.GetComponent<MouseLook>());
            StartY = cam.transform.rotation.y;

            StartX = 0;
            StartCoroutine(Spin(StartY, StartX));
        }
    }

  

    IEnumerator Spin(float startY, float startX)
    {
        
       
        while (blendY < (startY + 180))
        {
            blendY = startY + 180 *( Mathf.Lerp(0, 1, t / duration));
            blendX = startX + 30 * (Mathf.Lerp(0, 1, t / duration));
            Debug.Log("Y " + "blendX");
            Debug.Log("X " + "blendY");
            t += Time.deltaTime;
            
            cam.transform.eulerAngles = new Vector3(blendX, blendY, cam.transform.rotation.z);
            yield return null;
        }

    }
}
