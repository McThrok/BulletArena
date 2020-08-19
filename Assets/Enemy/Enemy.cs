using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int Hp = 50;
	public int Gold = 10;
	

	public void Start()
	{
		//hpbar
	}
	public void Update()
	{
		////update hp bar position
		//if (enemyList.Count > 0)
		//{
		//	var target = enemyList[0].transform;
		//	var wantedPos = Camera.main.WorldToViewportPoint(target.position);
		//	wantedPos.x *= Screen.width;
		//	wantedPos.y *= Screen.height;
		//	var go = GameObject.Find("Gold");
		//	go.transform.position = wantedPos;
		//}
	}
	public void Hit(int damage)
	{
		Hp -= damage;
		Hp = Math.Max(0, Hp);
		//update hpbar value
		if (Hp == 0)
			Die();

	}

	private void Die()
	{
		StageData.GetInstance().Gold += Gold;
		Destroy(this.gameObject);
	}
}
