using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
	Transform player;
	Transform tr;

	Vector3 velocity;
	float smoothTime = 0.2F;
	private void Awake()
	{
		tr = transform;
	}
	void Start()
	{
		player = PlayerManager.Instance.Player.gameObject.transform;
	}
	private void FixedUpdate()
	{
		if (player != null)
		{
			var pos = player.position;
			pos.y = tr.position.y;
			tr.position = Vector3.SmoothDamp(tr.position, pos, ref velocity, smoothTime);
		}
	}
}
