using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField]
	Camera camera;

	Plane plane;

	// Start is called before the first frame update
	void Start()
	{
		plane = new Plane(Vector3.up, Vector3.zero);
	}

	// Update is called once per frame
	void Update()
	{
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		if (plane.Raycast(ray, out float hit))
		{
			Vector3 hitPoint = ray.GetPoint(hit);
			transform.position = hitPoint;
		}
	}
}
