using UnityEngine;
using System.Collections;
// this using 
using Pathfinding;

public class EnemyPathfinder : MonoBehaviour
{
    // change this vector to the mouseclick
    public Vector2 targetPosition;
    private Seeker _seeker;
    private CharacterController _cont;  
    public Path path;
    [SerializeField]
    private float speed = 5;
    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    public void Start()
    {
        _seeker = GetComponent<Seeker>();
        _cont = GetComponent<CharacterController>();
        //Start a new path to the targetPosition, return the result to the OnPathComplete function
        _seeker.StartPath(transform.position, targetPosition, OnPathComplete);
    }
    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }
    public void Update()
    {
        if (path == null)
        {
            //We have no path to move after yet
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("End Of Path Reached");
            return;
        }
        //Direction to the next waypoint
        Vector2 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.deltaTime;
        _cont.Move(dir);
        Debug.Log(dir);
        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}
 