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
    public NavMeshAgent agentJohny;
    public NavMeshAgent agent;
    public NavMeshAgent agent2;
    public NavMeshAgent agent3;
    public NavMeshAgent agent4;
    public NavMeshAgent agent5;
    public NavMeshAgent agent6;
    public NavMeshAgent agent7;
    public NavMeshAgent agent8;
    public NavMeshAgent agent9;
    public NavMeshAgent agent10;

    private bool fiveSecondsPassed = false;
    private float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check if 5 seconds have passed
/*        if (!fiveSecondsPassed)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 5f)
            {
                fiveSecondsPassed = true;
                // Additional logic to execute after 5 seconds if needed
            }
        }*/

        foreach (var plane in ARPlaneManager.trackables)
        {
            if (plane.transform.position.y < player.position.y)
            {
                plane.GetComponent<NavMeshSurface>().BuildNavMesh();
                agentJohny.enabled = true;
                agent.enabled = true;
                agent2.enabled = true;
                agent3.enabled = true;
                agent4.enabled = true;
                agent5.enabled = true;
                agent6.enabled = true;
                agent7.enabled = true;
                agent8.enabled = true;
                agent9.enabled = true;
                agent10.enabled = true;
            }
        }
    }
}
