using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Spawner : MonoBehaviour
{
	public GameObject Spawn(GameObject enemyPrefab)
	{
		var go = Instantiate(enemyPrefab, GetSpawnPosition(), Quaternion.identity);
		return go;
	}
	Vector3 GetSpawnPosition()
	{
		Random.Range(-10, 10);
		return new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
	}
}
