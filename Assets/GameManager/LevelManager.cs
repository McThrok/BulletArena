using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Threading;

public class LevelManager : MonoBehaviour
{
	[SerializeField] List<LevelData> levels;
	[SerializeField] GameObject enemy;
	[SerializeField] Spawner spawner;
	private Player player;

	private LevelData LevelData;
	private int enemiesToSpawn;
	private float currentSpawnTime = 0;
	private List<GameObject> enemyList = new List<GameObject>();

	void Start()
	{
		player = PlayerManager.Instance.Player.GetComponent<Player>();
		LoadNextLevel();
	}

	void Update()
	{
		SpawnUpdate();
	}
	public void SpawnUpdate()
	{
		var spawnTime = LevelData.SpawnTime;

		currentSpawnTime += Time.deltaTime;
		while (currentSpawnTime >= spawnTime && enemiesToSpawn > 0)
		{
			currentSpawnTime -= spawnTime;
			var go = spawner.Spawn(enemy);
			enemiesToSpawn--;
			enemyList.Add(go);
		}

		enemyList = enemyList.Where(x => x != null).ToList();
		if (enemyList.Count == 0 && enemiesToSpawn == 0)
			EndLevel(MenuState.Shop);
	}

	public void LoadNextLevel()
	{
		LevelData = levels[GameState.GetInstance().LevelNumber];
		GameState.GetInstance().LevelNumber++;
		enemiesToSpawn = LevelData.EnemyCount;
	}
	public void EndLevel(MenuState state)
	{
		GameState.GetInstance().MenuState = state;
		SceneManager.LoadScene("Menu");
	}
}
