using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Linq;

public class StageManager : MonoBehaviour
{
	[SerializeField] GameObject enemy;
	Player player;

	float spawnTime = 3;
	float currentSpawnTime = 0;
	int enemies = 3;
	List<GameObject> enemyList = new List<GameObject>();
	void Start()
	{
		player = GameObject.Find("Player")?.GetComponent<Player>();
	}

	void Update()
	{
		currentSpawnTime += Time.deltaTime;
		while (currentSpawnTime >= spawnTime && enemies > 0)
		{
			currentSpawnTime -= spawnTime;
			var go = Instantiate(enemy, GetSpawnPosition(), Quaternion.identity);
			enemies--;
			enemyList.Add(go);
		}

		enemyList = enemyList.Where(x => x != null).ToList();
		if (enemyList.Count == 0 && enemies == 0)
			SceneManager.LoadScene("ShopMenu");

	}
	Vector3 GetSpawnPosition()
	{
		Random.Range(-10, 10);
		return new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
	}
}

public class StageData
{
	public int Round;
	public int MinigunLvl;

	public void Reset()
	{
		Round = 1;
		MinigunLvl = 1;
	}

	static StageData instance;
	public static StageData GetInstance()
	{
		if (instance == null)
		{
			instance = new StageData();
			instance.Reset();
		}

		return instance;
	}
}
