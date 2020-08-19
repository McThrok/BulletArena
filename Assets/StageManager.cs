using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Threading;

public class StageManager : MonoBehaviour
{
	[SerializeField] List<LevelData> Levels;
	[SerializeField] GameObject enemy;
	Player player;

	int enemiesToSpawn;
	float currentSpawnTime = 0;
	List<GameObject> enemyList = new List<GameObject>();

	void Start()
	{
		player = PlayerManager.Instance.Player.GetComponent<Player>();
		var sd = StageData.GetInstance();
		sd.LoadNextLevel(Levels[sd.Number]);
		enemiesToSpawn = sd.LevelData.EnemyCount;
	}

	void Update()
	{
		var sd = StageData.GetInstance();
		var spawnTime = sd.LevelData.SpawnTime;

		currentSpawnTime += Time.deltaTime;
		while (currentSpawnTime >= spawnTime && enemiesToSpawn > 0)
		{
			currentSpawnTime -= spawnTime;
			var go = Instantiate(enemy, GetSpawnPosition(), Quaternion.identity);
			enemiesToSpawn--;
			enemyList.Add(go);
		}

		enemyList = enemyList.Where(x => x != null).ToList();
		if (enemyList.Count == 0 && enemiesToSpawn == 0)
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
	public int Number;
	public int MinigunLvl;
	public int Gold;
	public LevelData LevelData;

	public void Reset()
	{
		Number = 0;
		MinigunLvl = 1;
		Gold = 0;
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

	public void LoadNextLevel(LevelData data)
	{
		Number++;
		LevelData = data;
	}
}
