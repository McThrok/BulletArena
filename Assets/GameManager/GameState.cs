using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class GameState
{
	public MenuState MenuState = MenuState.Start;
	public int LevelNumber = 0;

	private GameState() { }
	private static GameState instance;
	public static GameState GetInstance()
	{
		if (instance == null)
			instance = new GameState();
		return instance;
	}

	public void Reset()
	{
		LevelNumber = 0;
		MenuState = MenuState.Start;

		ShopState.GetInstance().Reset();
	}
}
public enum MenuState
{
	Start,
	Shop,
	Defeat,
	Victor
}
