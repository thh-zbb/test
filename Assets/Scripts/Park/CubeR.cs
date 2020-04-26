using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeR : MonoBehaviour
{

    public float speed = 60f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,1f,0f) * Time.deltaTime * speed);
    }

    public void ChangeSpeed(float speedNew)
    {
        this.speed = speedNew;
    }
}
