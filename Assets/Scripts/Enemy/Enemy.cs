using UnityEngine;
using System.Collections;

public class Enemy : TempleCollision
{
    [SerializeField] private GameObject _healthBar;
    public float health = 100;
    private bool _attacking = false;
    private Animator _animator;

    public override void TempleCollide(BaseTemple _BT)
    {
        base.TempleCollide(_BT);
        _animator.SetBool("isAttacking", true);
        InvokeRepeating("AttackTemple", 0.9f, 1);
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
	
	void Update ()
    {
        if (health == 50)
        {
            _healthBar.transform.localScale = new Vector3(0.9f, 3, 0);
        }

        if (health <= 0)
        {
            _healthBar.SetActive(false);
            _animator.SetBool("isDead", true);
            StartCoroutine("DestroyObject");
        }
	}

    private void AttackTemple()
    {
        GameObject.Find("Temple").GetComponent<BaseTemple>().health -= 20f;
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.9f);
        GameObject.Find("_ResourceCountScript").GetComponent<ResourceCount>().resourceCounter += 50f;
        Destroy(this.gameObject);
    }
}
