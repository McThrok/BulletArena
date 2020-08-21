using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMinigun : WeaponPart
{
	[SerializeField] private GameObject Bullet;
	[SerializeField] private float BulletSize = 0.2f;
	public int Damage;

	public override void Shoot()
	{
		var pos = transform.position + transform.forward * 0.5f;
		var b = Instantiate(Bullet, pos, transform.rotation);
		b.transform.localScale = BulletSize * Vector3.one;
		b.GetComponent<Bullet>().Damage = Damage;
		b.GetComponentInChildren<Renderer>().material.color = Colors[Level - 1];
	}

	protected override void UpdateLevel()
	{
		GetComponentInChildren<Renderer>().material.color = Colors[Level - 1];
	}
}
