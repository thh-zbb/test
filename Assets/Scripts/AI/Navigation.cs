using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{

    public GameObject go;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(go.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(go.transform.position);
    }



}
