using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] GameObject bullet;
	[SerializeField] GameObject weapon;
	GameObject a;
	float shotTime = 0.1f;
	float currentShotTime = 0;
	int hp = 50;
	void Start()
	{
		a = WeaponManager.Instance.GetWeapon(transform).gameObject;
	}

	void Update()
	{
		Movement();
		Shoot();
	}
	Vector3 moveDir= Vector3.zero;
	Quaternion moveRot = Quaternion.identity;
	void Movement()
	{
		moveDir = Vector3.zero;

		if (Input.GetKey(KeyCode.A))
			moveDir += Vector3.left;
		if (Input.GetKey(KeyCode.D))
			moveDir += Vector3.right;
		if (Input.GetKey(KeyCode.W))
			moveDir += Vector3.forward;
		if (Input.GetKey(KeyCode.S))
			moveDir += Vector3.back;

		moveRot = Quaternion.FromToRotation(Vector3.forward, target.position - transform.position);

	}
	private void FixedUpdate()
	{
		GetComponent<Rigidbody>().MoveRotation(moveRot);
		//transform.rotation = moveRot;
		if (moveDir.sqrMagnitude == 0)
			return;

		float speed = 12f;
		var newPos = transform.position + moveDir.normalized * speed * Time.fixedDeltaTime;
		newPos.x = Mathf.Clamp(newPos.x, -19.5f, 19.5f);
		newPos.z = Mathf.Clamp(newPos.z, -19.5f, 19.5f);
		GetComponent<Rigidbody>().MovePosition(newPos);
		//transform.position = newPos;
	}

	void Shoot()
	{
		currentShotTime -= Time.deltaTime;
		if (currentShotTime <= 0 && Input.GetMouseButton(0))
		{
			currentShotTime += shotTime;
			a.GetComponent<Minigun>().Shoot();
		}
		currentShotTime = Mathf.Max(currentShotTime, 0);
	}
	public void Hit(int damage)
	{
		hp -= damage;
		if (hp <= 0)
			Die();
	}
	private void Die()
	{
	}
}
