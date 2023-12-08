using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    NavMeshAgent agent;
    float speed = 5;
    public  int layerMask = 6;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray movePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerGround = 1<< layerMask;
            if(Physics.Raycast(movePos, out var hitInfo, Mathf.Infinity, 1 << 6))
            {
               Debug.Log(hitInfo.collider.gameObject.layer);
                agent.SetDestination(hitInfo.point);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            agent.speed = 5;
        }
        else
        {
            agent.speed = 3.5f;
        }
    }
}
