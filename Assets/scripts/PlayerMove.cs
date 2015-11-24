using UnityEngine;
using System.Collections;
// this using 
using Pathfinding;

public class PlayerMove : MonoBehaviour
    {
     // change this vector to the mouseclick
     [SerializeField]
     private Vector2 targetPosition;
     private Seeker _seeker;
     private CharacterController _cont;

     private Path path;
     [SerializeField]
      private float _Mspeed = 5;
      //The max distance from the AI to a waypoint for it to continue to the next waypoint
     private float _nextWayDist = 3;
      //The waypoint we are currently moving towards
    private int _currPoint = 0;
  
    
         void Start()
        {
            _seeker = GetComponent<Seeker>();
            _cont = GetComponent<CharacterController>();
        //Start a new path to the targetPosition, return the result to the OnPathComplete function
        _seeker.StartPath(transform.position, targetPosition, OnPathComplete);


    }



    void OnPathComplete(Path p)
        {
            Debug.Log("Yay, we got a path back, for the Hero. Did it have an error? " + p.error);
            if (!p.error)
            {
                path = p;
                //Reset the waypoint counter
                _currPoint = 0;
            }
        }
    void Clicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log(Input.mousePosition);
            targetPosition = Input.mousePosition;
            _seeker.StartPath(transform.position, targetPosition, OnPathComplete);


        }



    }
    void Update()
        {
             Clicked();

            if (path == null)
                {   
                    //We have no path to move after yet
                    return;
                }
                if (_currPoint >= path.vectorPath.Count)
                {
                    Debug.Log("End Of Path Reached");
                    return;
                }
                //Direction to the next waypoint
                Vector2 dir = (path.vectorPath[_currPoint] - transform.position).normalized;
                dir *= _Mspeed * Time.deltaTime;
                _cont.Move(dir);
                //Check if we are close enough to the next waypoint
                //If we are, proceed to follow the next waypoint
                if (Vector2.Distance(transform.position, path.vectorPath[_currPoint]) < _nextWayDist)
                {
                    _currPoint++;
                    return;
            }
        }
    }
