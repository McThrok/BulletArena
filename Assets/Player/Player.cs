﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] GameObject hpBar;

	Slider hpSlider;

	List<Weapon> weapons;
	float shotTime = 0.1f;
	float currentShotTime = 0;
	int hp = 50;
	int maxHp = 5000;
	void Start()
	{
		weapons = WeaponManager.Instance.GetWeapons(transform);
		hpSlider = hpBar.GetComponent<Slider>();
		hpSlider.value = 1;
		hp = maxHp;
	}

	void Update()
	{
		Shoot();
	}
	private void FixedUpdate()
	{
		Movement();
	}
	void Movement()
	{
		var toTarget = target.position - transform.position;
		toTarget.y = 0;
		transform.rotation = Quaternion.FromToRotation(Vector3.forward, toTarget);

		var moveDir = Vector3.zero;

		if (Input.GetKey(KeyCode.A))
			moveDir += Vector3.left;
		if (Input.GetKey(KeyCode.D))
			moveDir += Vector3.right;
		if (Input.GetKey(KeyCode.W))
			moveDir += Vector3.forward;
		if (Input.GetKey(KeyCode.S))
			moveDir += Vector3.back;

		float speed = 12f;
		GetComponent<Rigidbody>().velocity = moveDir.normalized * speed;
	}

	void Shoot()
	{
		foreach (var weapon in weapons)
			weapon.Shoot();
	}
	public void Hit(int damage)
	{
		hp -= damage;
		hp = Mathf.Max(0, hp);
		hpSlider.value = 1.0f * hp / maxHp;
		if (hp == 0)
			Die();
	}
	private void Die()
	{
		Destroy(this.gameObject);
		LevelManager.Instance.EndLevel(MenuState.Defeat);
	}
}
