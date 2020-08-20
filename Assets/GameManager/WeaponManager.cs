﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject Minigun;
    public static WeaponManager Instance;
	void Awake()
	{
        Instance = this;
	}
	public Weapon GetWeapon(Transform parent)
	{
		var ss = ShopState.GetInstance();

		var minigunGO = Instantiate(Minigun, parent);
		var minigun = minigunGO.GetComponent<Minigun>();
		minigun.Level = ss.MinigunLvl;

		return minigun;
	}
}
