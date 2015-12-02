using UnityEngine;
using System.Collections;

public class LastEnemy : Enemy
{
    private GameObject _victory;

    public override void Start()
    {
        base.Start();

        _victory = GameObject.Find("Victory");
        _victory.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public override void Update()
    {
        if (health <= 0)
        {
            _victory.SetActive(true);
            Time.timeScale = 0;
        }

        base.Update();
    }
}