using UnityEngine;
using System.Collections;

public class swordActivate : MonoBehaviour {
    private float _aniLength;
    [SerializeField]
    private bool _tryAtack;
    [SerializeField]
    private bool _atacking;
    private bool _Strike;
   
	// Use this for initialization
	void Start () {
        _atacking = false;
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
            _atacking = false;
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(0.7f);
            _atacking = true;
            Debug.Log("strike");
            this.tag = "sword";
            yield return new WaitForSeconds(0.2f);
            _atacking = false;
            Debug.Log("no strike");
            this.tag = "docile";
            yield break;

        }

    }
}
