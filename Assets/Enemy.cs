using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	int Hp = 50;
	void Start()
	{

	}

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
		StageData.GetInstance().Gold += 10;
		Destroy(this.gameObject);
	}
}
