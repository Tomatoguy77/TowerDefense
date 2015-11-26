using UnityEngine;
using System.Collections;

public class PlayerAtack : PlayerControl {
    [HideInInspector]
    private PlayerControl _Player;
    [SerializeField]
    private BoxCollider2D _sword;
    private bool _wait;

    

    // Use this for initialization
    void Start () {
        _wait = false;
        Debug.Log("working");
        _sword = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update () {

        
        if (Input.GetKeyDown("space") && _wait == false)
        {
            StartCoroutine(PlayAni());
        }
       
    }

    IEnumerator PlayAni() {
        animatorPlayer.SetBool("isAtacking", true);
        _wait = true;
        yield return new WaitForSeconds(0.8f);
        animatorPlayer.SetBool("isAtacking", false);
        _wait = false;






    }

}
