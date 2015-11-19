using UnityEngine;
using System.Collections;

public class FollowWaypoint : MonoBehaviour
{
    private int _targetWaypoint = 0;
    private Transform _waypoints;
    [SerializeField] private float movementSpeed = 10f;
    
	void Start ()
    {
        _waypoints = GameObject.Find("Waypoints").transform;
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
            }
        }

        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(movementNormal.x, movementNormal.y) * movementSpeed);
        }

        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
    }
}
