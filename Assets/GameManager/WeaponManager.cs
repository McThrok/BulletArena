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

		var minigun = Instantiate(Minigun, parent).GetComponent<Minigun>();
		minigun.Level = ss.MinigunLvl;
		minigun.Level = 9;
		weapons.Add(minigun);

		var shotgun = Instantiate(Shotgun, parent).GetComponent<Shotgun>();
		shotgun.Level = ss.ShotgunLvl;
		shotgun.Level = 9;
		weapons.Add(shotgun);

		return weapons;
	}
}
