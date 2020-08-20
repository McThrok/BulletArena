using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponPart : Weapon
{
	protected List<Color> Colors;
	
	protected override void Start()
	{
		Colors = new List<Color>() {
			Color.green,
			Color.Lerp(Color.green,Color.yellow,0.75f),
			Color.yellow,
			Color.Lerp(Color.yellow,Color.red,0.5f),
			Color.red};

		base.Start();
	}
}
