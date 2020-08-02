using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Spawner : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] GameObject enemy;
	Player player;

	float spawnTime = 3;
	float currentSpawnTime = 0;
	void Start()
	{
		player = GameObject.Find("Player")?.GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{
		currentSpawnTime += Time.deltaTime;
		while (currentSpawnTime >= spawnTime)
		{
			currentSpawnTime -= spawnTime;
			var go = Instantiate(enemy, GetSpawnPosition(), Quaternion.identity);
		}
	}
	Vector3 GetSpawnPosition()
	{
		Random.Range(-10, 10);
		return new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
	}
}
