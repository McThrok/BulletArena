using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Minigun : Weapon
{
	[SerializeField] GameObject singleGun;
	List<int> Counts;
	List<int> Levels;
	protected override void Start()
	{
		Counts = new List<int> { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
		Levels = new List<int> { 1, 2, 3, 2, 3, 4, 3, 4, 5 };
	}
	public override void Shoot()
	{
		foreach (var weapon in GetComponentsInChildren<WeaponPart>())
			weapon.Shoot();
	}

	protected override void UpdateLevel()
	{
		var guns = GetComponentsInChildren<SingleMinigun>();

		foreach (var gun in guns)
			Destroy(gun.gameObject);

		int n = Counts[Level - 1];
		int lvl = Levels[Level - 1];
		float singleAngle = 180.0f / 5;

		for (int i = 0; i < n; i++)
		{
			var angle = i * singleAngle - (n - 1) * singleAngle / 2;
			var position = Quaternion.Euler(0, angle, 0) * transform.forward * 0.5f;
			var gun = Instantiate(singleGun, transform.position + position, transform.rotation, transform);
			gun.GetComponent<SingleMinigun>().Level = lvl;
		}
	}
}
