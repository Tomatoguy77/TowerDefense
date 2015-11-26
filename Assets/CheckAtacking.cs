using UnityEngine;
using System.Collections;

public class CheckAtacking : MonoBehaviour {
    private Collider _coll;
    private Rigidbody _rig;
  //  private PlayerControl _player;
    [SerializeField]
    private bool _isAtacking;
    [SerializeField]
    private bool _finishedAtacking;

 
    

	// Use this for initialization
	void Start () {
        _isAtacking = false;
        _finishedAtacking = true;
        this.tag = "docile";
        _coll = GetComponent<Collider>();
        _rig = GetComponent<Rigidbody>();
        _coll.isTrigger = false;
       
    }

    // Update is called once per frame
    void FixedUpdate () {
        //Debug.Log(_isAtacking);
        if (Input.GetKeyDown("space"))
        {
            //   this.tag = "sword";
            _isAtacking = true;
        }
        
        if (_isAtacking == true && _finishedAtacking == true)
        {
            //_finishedAtacking = false;
            StartCoroutine(Strike());
        }
      //  Debug.Log(_finishedAtacking);

	}
    
    IEnumerator Strike() {
        yield return new WaitForEndOfFrame();
        _finishedAtacking = false;
        yield return new WaitForSeconds(1);
        this.tag = "sword";
        yield return new WaitForSeconds(1);
        this.tag = "docile";
        _finishedAtacking = true;
        _isAtacking = false;
        yield break;
    }
}
