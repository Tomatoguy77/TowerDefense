using UnityEngine;
using System.Collections;

public class swordActivate : PlayerControl {
    private float _aniLength;
    [SerializeField]
    private bool _tryAtack;
    [SerializeField]
    private bool _atacking;
    private bool _Strike;
    private BoxCollider2D _sword;
    public int AtackStrength =50;


    // Use this for initialization
    void Start()
    {
        _atacking = false;
        _sword = GetComponent<BoxCollider2D>();
        _sword.enabled = false;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown("space"))
        {
            _tryAtack = true;
        }
        else
        {
            _tryAtack = false;
        }
        if (_tryAtack == true && _atacking == false)
        {
            StartCoroutine(Atack());
        }
       
	}
    IEnumerator Atack() {
        Debug.Log("begin strike");

        _atacking = true;
        if (Input.GetKeyUp("space"))
        {
            animatorPlayer.SetBool("isAtacking", false);

            _atacking = false;
            yield break;
        }
        else
        {
            animatorPlayer.SetBool("isAtacking", true);

            yield return new WaitForSeconds(0.8f);
            _atacking = true;
            Debug.Log("strike");
            _sword.enabled = true;
            yield return new WaitForSeconds(0.2f);
            _atacking = false;
            _sword.enabled = false;

            Debug.Log("no strike");
            animatorPlayer.SetBool("isAtacking", false);

            yield break;

        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "enemy")
        {
            Damage(AtackStrength,other.gameObject);
            
        }
    }

    void Damage(int dam, GameObject target) {
        target.GetComponent<Enemy>().health -= dam;
    }

}
