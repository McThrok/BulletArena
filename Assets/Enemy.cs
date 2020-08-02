using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public Player Player;

    int Hp = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	}


	public void Hit(int damage)
	{
        Hp -= damage;
        if (Hp <= 0)
            Die();
	}

    private void Die()
	{
            Destroy(this.gameObject);
	}
}
