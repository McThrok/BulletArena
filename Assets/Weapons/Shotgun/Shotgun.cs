using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Shotgun : Weapon
{
	[SerializeField] GameObject singleGun;
	List<int> Counts;
	List<int> Levels;

	[SerializeField] private float shotTime;
	private float currentShotTime;

	protected override void Start()
	{
		Counts = new List<int> { 3, 3, 3, 6, 6, 6, 9, 9, 9 };
		Levels = new List<int> { 1, 2, 3, 2, 3, 4, 3, 4, 5 };
	}
	public override void Shoot()
	{
		currentShotTime -= Time.deltaTime;
		if (currentShotTime <= 0 && Input.GetMouseButton(0))
		{
			currentShotTime += shotTime;
			foreach (var weapon in GetComponentsInChildren<WeaponPart>())
				weapon.Shoot();
		}
		currentShotTime = Mathf.Max(currentShotTime, 0);
	}

	protected override void UpdateLevel()
	{
		var guns = GetComponentsInChildren<SingleShotgun>();

		foreach (var gun in guns)
			Destroy(gun.gameObject);

		int n = Counts[Level - 1];
		int lvl = Levels[Level - 1];
		float singleAngle = 45 - n * 5 ;

		for (int i = 0; i < n; i++)
		{
			var angle = i * singleAngle - (n - 1) * singleAngle / 2;
			var position = Quaternion.Euler(0, angle, 0) * transform.forward * 0.5f;
			var rotation = transform.rotation * Quaternion.Euler(0, angle, 0);
			var gun = Instantiate(singleGun, transform.position + position, rotation, transform);
			gun.GetComponent<SingleShotgun>().Level = lvl;
		}
	}
}
