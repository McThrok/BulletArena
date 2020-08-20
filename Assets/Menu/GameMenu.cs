using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
	[SerializeField] GameObject ShopMenuCanvas;
	[SerializeField] GameObject MainMenuCanvas;
	[SerializeField] GameObject DefeatMenuCanvas;
	[SerializeField] GameObject VictoryMenuCanvas;

	private List<GameObject> menus;

	public void Start()
	{
		menus = new List<GameObject> { ShopMenuCanvas, MainMenuCanvas, DefeatMenuCanvas, VictoryMenuCanvas };

		var gs = GameState.GetInstance();
		switch (gs.MenuState)
		{
			case MenuState.Start: ActivateCanvas(MainMenuCanvas); return;
			case MenuState.Shop: ActivateCanvas(ShopMenuCanvas); return;
			case MenuState.Defeat: ActivateCanvas(DefeatMenuCanvas); return;
			case MenuState.Victor: ActivateCanvas(VictoryMenuCanvas); return;
		}
	}

	private void ActivateCanvas(GameObject canvas)
	{
		foreach (var menu in menus)
			menu.SetActive(false);

		canvas.SetActive(true);
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Game");
	}
	public void ReturToMainMenu()
	{
		ActivateCanvas(MainMenuCanvas);
	}

}
