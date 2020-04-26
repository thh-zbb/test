using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
   // public Transform target;                   //相机要跟随的对象

    public Transform target;

    public float smoothing = 5f;              //相机跟随平滑速度；
    public Vector3 offset;                   //偏移量



    // Start is called before the first frame update
    void Start()
    {
        
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position,targetCamPos,smoothing*Time.deltaTime);
        
    }
}
