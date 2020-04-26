using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    [SerializeField]
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {

        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //rb.transform.Translate(direction * Time.deltaTime * speed);
        transform.LookAt(new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical) + transform.position);
        Vector3 direction2 = Vector3.forward;
        float x = variableJoystick.Direction.x;
        float y = variableJoystick.Direction.y;
        if (x < 0)
        {
            x = -x;
        }
        if (y < 0)
        {
            y = -y;
        }
        Vector2 v2 = new Vector2(x, y);
        float r = (float)Math.Sqrt(x * x + y * y);
        //if (x>0.1f||y>0.1f)
        //{
           
           
        //}
        //else
        //{
            
        //}
        if(variableJoystick.Vertical!=0f || variableJoystick.Horizontal!=0f)
            {
            ani.SetInteger("state",1);
        }
        else
        {
            ani.SetInteger("state",0);
            
        }
        rb.transform.Translate(direction2 * Time.deltaTime * speed * r );

    }
}