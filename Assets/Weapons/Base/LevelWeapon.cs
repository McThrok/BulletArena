using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	private int level;
	public int Level;
	protected virtual void Start()
	{
		CheckLevel();
	}

	protected virtual void Update()
	{
		CheckLevel();
	}
	private void CheckLevel()
	{
		if (Level != level)
		{
			level = Level;
			UpdateLevel();
		}
	}

	protected abstract void UpdateLevel();
	public abstract void Shoot();
}

