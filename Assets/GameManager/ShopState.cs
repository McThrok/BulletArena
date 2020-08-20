using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShopState
{
	public int Gold;
	public int MinigunLvl;
	public int ShotgunLvl;

	[HideInInspector] public readonly int maxLvl = 9;
	[SerializeField] private const int basePrice = 0;
	[SerializeField] private const int stepBase = 10;
	[SerializeField] private const int stepIncrease = 5;

	private ShopState() { }
	private static ShopState instace;
	public static ShopState GetInstance()
	{
		if (instace == null)
			instace = new ShopState();
		return instace;
	}

	public int GetPriceForLevel(int lvl)
	{
		lvl = Mathf.Clamp(lvl, 0, maxLvl);
		return basePrice + (2 * stepBase + (lvl - 1) * stepIncrease) * lvl / 2;
	}
	public void Reset()
	{
		Gold = 0;
		MinigunLvl = 1;
		ShotgunLvl = 0;
	}
}
