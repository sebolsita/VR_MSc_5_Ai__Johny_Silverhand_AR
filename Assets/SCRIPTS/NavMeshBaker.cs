using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Unity.AI.Navigation;
using UnityEngine.AI;
using System.Drawing.Text;

public class NavMeshBaker : MonoBehaviour
{
    public ARPlaneManager ARPlaneManager;
    public Transform player;
    public NavMeshAgent agent;
    public NavMeshAgent agent2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var plane in ARPlaneManager.trackables)
        {
            if (plane.transform.position.y < player.position.y)
            {
                plane.GetComponent<NavMeshSurface>().BuildNavMesh();
                agent.enabled = true;
                agent2.enabled = true;
            }
        }
    }
}
