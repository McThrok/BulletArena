using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
	public Slider MinigunSlider;
	public Button MinigunButton;
	public TextMeshProUGUI GoldText;
	private void Start()
	{
		var sd = StageData.GetInstance();
		MinigunSlider.value = sd.MinigunLvl / 9.0f;
		ChangeGold();
	}
	public void BuyMinigun()
	{
		var sd = StageData.GetInstance();
		sd.MinigunLvl++;
		MinigunSlider.value = sd.MinigunLvl / 9.0f;
		ChangeGold(-10);
	}
	public void ChangeGold(int change=0)
	{
		var sd = StageData.GetInstance();
		sd.Gold += change;
		GoldText.text = $"Gold {sd.Gold}";
	}
}
