using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float speed = 2.5f;
    private Rigidbody2D _rig2d;
    private Vector2 _velo;
    public Animator animatorPlayer;
    private bool _facingRight;
    public Vector3 move;
  
    


    // Use this for initialization
    void Start () {
        _rig2d = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
        _facingRight = true;

    }
	
	void FixedUpdate () {
        //to make sure the player doesnt start moving during his atack animation
        if (Input.GetKey("space") == true )
        {
            move = Vector3.zero;
        }
        else
        {
            Movement();

        }
        FlipSprite();
        Animate();
        
    }
    private void Animate() {
        if (move != Vector3.zero)
        {
            animatorPlayer.SetBool("isWalking", true);

        }
        else
        {
            animatorPlayer.SetBool("isWalking", false);

        }
        //switching up this bool to flip the player sprite
        if (move.x < 0)
        {
            _facingRight = false;
        }
        if (move.x > 0)
        {
            _facingRight = true;

        }
        if (Input.GetKeyDown("space"))
        {
            animatorPlayer.SetBool("isAtacking", true);
        }
    }
    public void Movement() {

         move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.position += move * speed * Time.deltaTime;
     

    }
    void FlipSprite()
    {
        Vector3 theScale = transform.localScale;

        // Switch the way the player is labelled as facing
        if (_facingRight == false)
        {
            theScale.x = -1;
        }
        else
        {
            theScale.x = 1;
        }
            transform.localScale = theScale;

        


    }
   

}
