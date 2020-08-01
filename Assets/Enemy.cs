using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player Player;

    int Hp = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
            return;

        Movement();
    }

	private void Movement()
	{
        var toPlayer = Player.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.forward, toPlayer);
        transform.position += transform.forward * Time.deltaTime * 2;

	}

	public void Hit()
	{
        Hp -= 10;
        if (Hp <= 0)
            Destroy(this.gameObject);
	}
}
