using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public MenuState MenuState = MenuState.Start;
    public int LevelNumber = 1;

    private GameState() {}
    private static GameState instance;
    public static GameState GetInstance()
	{
        if (instance == null)
            instance = new GameState();
        return instance;
	}
}
public enum MenuState
{
    Start,
    Shop,
    Defeat,
    Victor
}
