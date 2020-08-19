using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public int MaxHp = 50;
	public int Gold = 10;
	public GameObject HpBar;
	public Transform EnemyBody;

	int hp;
	Slider slider;
	Transform sliderTr;

	public void Start()
	{
		hp = MaxHp;
		slider = HpBar.GetComponent<Slider>();
		sliderTr = HpBar.transform;
		UpdateHpBar();
	}
	public void Update()
	{
		UpdateHpBar();
	}
	private void UpdateHpBar()
	{
		var wantedPos = Camera.main.WorldToViewportPoint(EnemyBody.position);
		wantedPos.x *= Screen.width;
		wantedPos.y *= Screen.height;
		sliderTr.position = wantedPos;
		slider.value = 1.0f * hp / MaxHp;
		HpBar.SetActive(slider.value != 1);
	}
	public void Hit(int damage)
	{
		hp -= damage;
		hp = Math.Max(0, hp);
		if (hp == 0)
			Die();
	}

	private void Die()
	{
		StageData.GetInstance().Gold += Gold;
		Destroy(this.gameObject);
	}
}
