using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public Slider MinigunSlider;
	public Button MinigunButton;
	public void StartLevel()
	{
		SceneManager.LoadScene("Game");
	}
	private void Start()
	{
		var sd = StageData.GetInstance();
		MinigunSlider.value = sd.MinigunLvl / 9.0f;
	}
	public void BuyMinigun()
	{
		var sd = StageData.GetInstance();
		sd.MinigunLvl++;
		MinigunSlider.value = sd.MinigunLvl / 9.0f;
	}
}
