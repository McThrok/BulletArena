using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShopState
{
	public int Gold = 0;
	public int MinigunLvl = 1;

	[HideInInspector] public readonly int maxLvl = 9;
	[SerializeField] private const int basePrice = -15;
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
		lvl = Mathf.Clamp(lvl, 1, maxLvl);
		return basePrice + (2 * stepBase + (lvl - 1) * stepIncrease) * lvl / 2;
	}
}
