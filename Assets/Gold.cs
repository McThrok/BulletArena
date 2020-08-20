using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    Text text;
	private void Awake()
	{
        text = GetComponent<Text>();
	}
	void Start()
    {
        
    }

    void Update()
    {
        text.text = $"Gold: {ShopState.GetInstance().Gold}";
    }
}
