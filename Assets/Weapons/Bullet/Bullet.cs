using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int Damage = 10;
	private float speed = 20;
	void Start()
	{
		GetComponent<Rigidbody>().velocity = transform.forward  * speed;
		Destroy(gameObject, 3.0f);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<Bullet>() != null)
			return;

		if (other.gameObject.GetComponent<Player>() != null)
			return;

		other.gameObject.GetComponentInParent<Enemy>()?.Hit(Damage);
		Destroy(gameObject);
		gameObject.SetActive(false);
	}
}
