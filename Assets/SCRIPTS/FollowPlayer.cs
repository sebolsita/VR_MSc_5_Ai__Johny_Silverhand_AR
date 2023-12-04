using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public NavMeshAgent agent2;
    public Transform player;

    private Animator animator;

    private float updateInterval = 1f;
    private float updateTimer = 0f;

    private void Start()
    {
        if (agent2 == null)
        {
            agent2 = GetComponent<NavMeshAgent>();
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (agent2 == null || player == null)
        {
            Debug.LogError("Agent or player not found. Make sure to assign the agent and player in the inspector or have the player tagged.");
        }

        // Get the Animator component on the agent GameObject
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found. Make sure to attach an Animator component to the agent GameObject.");
        }
    }

    private void Update()
    {
        if (agent2.enabled == false || player == null)
        {
            return;
        }

        // Update the timer
        updateTimer += Time.deltaTime;

        // Check if it's time to update the destination
        if (updateTimer >= updateInterval)
        {
            // Set the destination to the player's position
            agent2.SetDestination(player.position);

            // Calculate the speed of the agent based on NavMeshAgent's velocity
            float speed = agent2.velocity.magnitude;

            // Update the Animator parameters
            animator.SetFloat("Speed", speed);

            // Rotate the agent to face the player
            RotateAgentTowardsPlayer();

            // Reset the timer
            updateTimer = 0f;
        }
    }

    private void RotateAgentTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}