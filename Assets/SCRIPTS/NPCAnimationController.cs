using UnityEngine;
using UnityEngine.AI;

public class NPCAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Get the Animator component attached to this NPC
        animator = GetComponent<Animator>();

        // Check if the Animator component exists
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this NPC.");
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
        // Check if the Animator and NavMeshAgent components are valid
        if (animator != null && navMeshAgent != null)
        {
            // Calculate the speed percentage based on the NavMeshAgent's speed
            float speedPercentage = navMeshAgent.velocity.magnitude / navMeshAgent.speed;

            // Set the "Speed" parameter in the blend tree to control the animation
            animator.SetFloat("Speed", speedPercentage);
        }
    }
}