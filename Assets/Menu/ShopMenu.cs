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
	private TextMeshProUGUI MinigunButtonText;

	public TextMeshProUGUI GoldText;
	private void Start()
	{
		MinigunButtonText = MinigunButton.GetComponentInChildren<TextMeshProUGUI>();
		ChangeGold(0);

		UpdateMinigunUI();
	}
	public void BuyMinigun()
	{
		var ss = ShopState.GetInstance();
		ss.MinigunLvl++;
		var price = ss.GetPriceForLevel(ss.MinigunLvl);
		ChangeGold(-price);
	}
	public void ChangeGold(int change)
	{
		var ss = ShopState.GetInstance();
		ss.Gold += change;
		GoldText.text = $"Gold {ss.Gold}";
		UpdateMinigunUI();
	}
	private void UpdateMinigunUI()
	{
		var ss = ShopState.GetInstance();

		if (ss.MinigunLvl == ss.maxLvl)
		{
			MinigunSlider.value = 1;
			MinigunButton.gameObject.SetActive(false);
			return;
		}

		MinigunButtonText.text = ss.GetPriceForLevel(ss.MinigunLvl + 1).ToString();
		MinigunSlider.value = 1.0f * ss.MinigunLvl / ss.maxLvl;

		var price = ss.GetPriceForLevel(ss.MinigunLvl);
		if (ss.Gold >= price)
		{
			MinigunButton.interactable = true;
			MinigunButtonText.color = Color.white;
		}
		else
		{
			MinigunButton.interactable = false;
			MinigunButtonText.color = Color.white / 2;
		}
	}
}
