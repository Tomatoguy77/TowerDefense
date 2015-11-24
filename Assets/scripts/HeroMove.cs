using UnityEngine;
using System.Collections;

public class HeroMove : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed;
    private Vector3 _moveTarget;


    // Use this for initialization
    void Start()
    {
        _moveTarget = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        CheckFloor();
        MoveTo();
    }

    void CheckFloor() {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if (hit)
        {
            // check what tag the place of the mouse has

            switch (hit.transform.tag)
            {
                case "ground":
                    if (Input.GetMouseButton(0))
                    {
                        _moveTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    }
                    break;

                default:
                    break;
            }
            Debug.Log(hit.transform.tag);
        }

    }

    void MoveTo() {

        if (transform.position != _moveTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, _moveTarget, Time.deltaTime * _moveSpeed);

        }

    }

    
}
