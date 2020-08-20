using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	public GameObject Minigun;
	public GameObject Shotgun;
	public static WeaponManager Instance;
	void Awake()
	{
		Instance = this;
	}
	public List<Weapon> GetWeapons(Transform parent)
	{
		var weapons = new List<Weapon>();
		var ss = ShopState.GetInstance();

		if (ss.MinigunLvl > 0)
		{
			var minigun = Instantiate(Minigun, parent).GetComponent<Minigun>();
			minigun.Level = ss.MinigunLvl;
			weapons.Add(minigun);
		}

		if (ss.ShotgunLvl > 0)
		{
			var shotgun = Instantiate(Shotgun, parent).GetComponent<Shotgun>();
			shotgun.Level = ss.ShotgunLvl;
			weapons.Add(shotgun);
		}

		return weapons;
	}
}
