using UnityEngine;
using System.Collections;

public class FollowWaypoint : TempleCollision
{
    private int _targetWaypoint = 0;
    private Transform _waypoints;
    private float _movementSpeed = 10f;
    private int _choosePath;
    
	void Start ()
    {
        _choosePath = Random.Range(0, 2);
        if (_choosePath == 1)
        {
            _waypoints = GameObject.Find("WaypointsUpPath").transform;

        }

        else
        {
            _waypoints = GameObject.Find("WaypointsDownPath").transform;
        }
	}
	
	void FixedUpdate ()
    {
        HandleWaypoints();
	}

    private void HandleWaypoints()
    {
        Transform targetWaypoint = _waypoints.GetChild(_targetWaypoint);
        Vector3 relative = targetWaypoint.position - transform.position;
        Vector3 movementNormal = Vector3.Normalize(relative);
        float distanceToWaypoint = relative.magnitude;
        float targetAngle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg - 90;

        if (distanceToWaypoint < 0.1)
        {
            if(_targetWaypoint + 1 < _waypoints.childCount)
            {
                _targetWaypoint++;
            }

            else
            {
                print("Eindpunt berijkt");
                _movementSpeed = 0f;
            }
        }

        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(movementNormal.x, movementNormal.y) * _movementSpeed);
        }
    }
}
