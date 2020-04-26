using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common2;

public class Ray : MonoBehaviour
{

    public GameObject attributePanel;

    GetAttributeRequest getAttributeRequest;

    public bool rayBool;

    // Start is called before the first frame update
    void Start()
    {
        getAttributeRequest = GetComponent<GetAttributeRequest>();
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UnityEngine.Ray ray;
            ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                string name = hit.collider.gameObject.GetComponent<Player>().userName;
                Debug.Log("被射中的角色："+name);
                if(name!="")
                {
                    attributePanel.SetActive(true);
                    getAttributeRequest.username = name;
                    getAttributeRequest.DefaultRequse();
                    
                }     
            }
        }
    }

    public void OnOperationResponse()
    {

    }

}
