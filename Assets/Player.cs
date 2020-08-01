﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] Transform target;
	[SerializeField] GameObject bullet;

	float shotTime = 0.1f;
	float currentShotTime = 0;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Movement();
		Target();
		Shoot();
	}
	void Movement()
	{
		float speed = 12f;
		Vector3 dir = Vector3.zero;

		if (Input.GetKey(KeyCode.A))
			dir += Vector3.left;
		if (Input.GetKey(KeyCode.D))
			dir += Vector3.right;
		if (Input.GetKey(KeyCode.W))
			dir += Vector3.forward;
		if (Input.GetKey(KeyCode.S))
			dir += Vector3.back;

		transform.position += dir.normalized * speed * Time.deltaTime;
	}
	void Target()
	{
		transform.rotation = Quaternion.FromToRotation(Vector3.forward, target.position - transform.position);
	}
	void Shoot()
	{
		currentShotTime -= Time.deltaTime;
		if (currentShotTime <= 0 && Input.GetMouseButton(0))
		{
			currentShotTime += shotTime;
			var pos = transform.position + transform.rotation * new Vector3(0, 0, 0.5f);
			var b = Instantiate(bullet, pos, transform.rotation);
		}
		currentShotTime = Math.Max(currentShotTime, 0);
	}
}