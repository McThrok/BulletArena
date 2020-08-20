using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotgun : WeaponPart
{
	[SerializeField] GameObject Bullet;
	float Size = 1;

	public override void Shoot()
	{
		var pos = transform.position + transform.forward * 0.5f;
		var b = Instantiate(Bullet, pos, transform.rotation);
		b.transform.localScale = Size * Vector3.one;
		b.GetComponentInChildren<Renderer>().material.color = Colors[Level - 1];
	}

	protected override void UpdateLevel()
	{
		GetComponentInChildren<Renderer>().material.color = Colors[Level - 1];
	}
}
