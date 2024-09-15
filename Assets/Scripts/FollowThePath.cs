// using UnityEngine;

// public class FollowThePath : MonoBehaviour {

//     // Array of waypoints to walk from one to the next one
//     [SerializeField]
//     private Transform[] waypoints;

//     // Walk speed that can be set in Inspector
//     [SerializeField]
//     private float moveSpeed = 2f;

//     // Index of current waypoint from which Enemy walks
//     // to the next one
//     private int waypointIndex = 0;

// 	// Use this for initialization
// 	private void Start () {

//         // Set position of Enemy as position of the first waypoint
//         transform.position = waypoints[waypointIndex].transform.position;
// 	}
	
// 	// Update is called once per frame
// 	private void Update () {

//         // Move Enemy
//         Move();
// 	}

//     // Method that actually make Enemy walk
//     private void Move()
//     {
//         // If Enemy didn't reach last waypoint it can move
//         // If enemy reached last waypoint then it stops
//         if (waypointIndex <= waypoints.Length - 1)
//         {

//             // Move Enemy from current waypoint to the next one
//             // using MoveTowards method
//             transform.position = Vector2.MoveTowards(transform.position,
//                waypoints[waypointIndex].transform.position,
//                moveSpeed * Time.deltaTime);

//             // If Enemy reaches position of waypoint he walked towards
//             // then waypointIndex is increased by 1
//             // and Enemy starts to walk to the next waypoint
//             if (transform.position == waypoints[waypointIndex].transform.position)
//             {
//                 waypointIndex += 1;
//             }
//         }
//     }
// }

using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;  // Array of points the enemy will follow
    private int currentWaypointIndex = 0;  // Keep track of the current waypoint
    public float speed = 2f;  // Speed at which the enemy moves

    void Update()
    {
        if (waypoints.Length == 0) return;  // If there are no waypoints, do nothing

        // Move towards the next waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];  // Get the current target waypoint
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);  // Move enemy towards waypoint

        // Check if the enemy reached the waypoint
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)  // When enemy is very close to the waypoint
        {
            currentWaypointIndex++;  // Move to the next waypoint in the list
            if (currentWaypointIndex >= waypoints.Length)  // If all waypoints have been reached
            {
                // Notify WaveManager the enemy is done, and then destroy the enemy
                WaveManager waveManager = FindObjectOfType<WaveManager>();
                waveManager.EnemyDefeated();

                Destroy(gameObject);  // Destroy the enemy after reaching the final waypoint
            }
        }
    }
}
