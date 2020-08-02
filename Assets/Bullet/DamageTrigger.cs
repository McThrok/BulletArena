using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<DamageTrigger>() != null)
			return;

		other.gameObject.GetComponentInParent<Enemy>()?.Hit(10);
		Destroy(gameObject.transform.parent.gameObject);
	}
}
