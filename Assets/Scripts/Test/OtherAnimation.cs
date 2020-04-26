using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherAnimation : MonoBehaviour
{

    public Vector3 lastPos;
    public Vector3 nowPos;

    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        lastPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,lastPos)>0.1)
        {
            ani.SetInteger("cstate",1);
            lastPos = transform.position;
        }
        else
        {
            ani.SetInteger("cstate",0);
        }
    }
}
