using UnityEngine;
using UnityEngine.AI;

public class NPCFollowPlayer : MonoBehaviour
{
    public string playerTag = "Player";
    private Transform playerTransform;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Find the player object based on the tag
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        // Check if the player object exists
        if (player != null)
        {
            // Get the player's transform component
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player object not found. Make sure the player object is tagged as 'Player'.");
        }

        // Get the NavMeshAgent component attached to this NPC
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Check if the NavMeshAgent component exists
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found on this NPC.");
        }
    }

    void Update()
    {
        // Check if both playerTransform and navMeshAgent are valid
        if (playerTransform != null && navMeshAgent != null)
        {
            // Set the destination of the NPC to the player's position
            navMeshAgent.SetDestination(playerTransform.position);
        }
    }
}