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

	public Slider ShotgunSlider;
	public Button ShotgunButton;
	private TextMeshProUGUI ShotgunButtonText;

	public TextMeshProUGUI GoldText;
	private void Start()
	{
		MinigunButtonText = MinigunButton.GetComponentInChildren<TextMeshProUGUI>();
		ShotgunButtonText = ShotgunButton.GetComponentInChildren<TextMeshProUGUI>();
		ChangeGold(0);
	}
	public void StartGame()
	{
		SceneManager.LoadScene("Game");
	}
	private void UpdateUI()
	{
		UpdateMinigunUI();
		UpdateShotgunUI();
	}
	public void ChangeGold(int change)
	{
		var ss = ShopState.GetInstance();
		ss.Gold += change;
		GoldText.text = $"Gold {ss.Gold}";
		UpdateUI();
	}
	public void BuyMinigun()
	{
		var ss = ShopState.GetInstance();
		ss.MinigunLvl++;
		var price = ss.GetPriceForLevel(ss.MinigunLvl);
		ChangeGold(-price);
	}
	public void BuyShotgun()
	{
		var ss = ShopState.GetInstance();
		ss.ShotgunLvl++;
		var price = ss.GetPriceForLevel(ss.ShotgunLvl);
		ChangeGold(-price);
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

		var price = ss.GetPriceForLevel(ss.MinigunLvl + 1);
		MinigunButtonText.text = price.ToString();
		MinigunSlider.value = 1.0f * ss.MinigunLvl / ss.maxLvl;

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
	private void UpdateShotgunUI()
	{
		var ss = ShopState.GetInstance();

		if (ss.ShotgunLvl == ss.maxLvl)
		{
			ShotgunSlider.value = 1;
			ShotgunButton.gameObject.SetActive(false);
			return;
		}

		var price = ss.GetPriceForLevel(ss.ShotgunLvl + 1);
		ShotgunButtonText.text = price.ToString();
		ShotgunSlider.value = 1.0f * ss.ShotgunLvl / ss.maxLvl;

		if (ss.Gold >= price)
		{
			ShotgunButton.interactable = true;
			ShotgunButtonText.color = Color.white;
		}
		else
		{
			ShotgunButton.interactable = false;
			ShotgunButtonText.color = Color.white / 2;
		}
	}
}
