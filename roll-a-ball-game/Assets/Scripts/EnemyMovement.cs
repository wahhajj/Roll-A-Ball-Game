using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

   

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Subscribe to the game start event (if you have one), or set up a reference to track when the game unpauses
        PlayerController.instance.StartCoroutine(WaitForGameStart());
    }

    void Update()
    {
        if (CountDownController.isGameStarted && player != null) // Only move if the game is not paused
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    private IEnumerator WaitForGameStart()
    {
        // Wait until the game is unpaused
        while (PlayerController.instance != null && PlayerController.instance.isGamePaused)
        {
            yield return null; // Wait for the next frame
        }
    }
}
