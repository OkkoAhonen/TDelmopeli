using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentWaveIndex, currentLevelIndex;

    public bool canSpawn;

    public float maxHealth, health;

    private Vector3 enemySpawnPos;

    public string wave;

    public List<string> level;

    public List<List<string>> levels = new();

    public GameObject[] enemyPrefabs;

    void Start()
    {
        Makelevels();
        enemySpawnPos = GameObject.Find("EnemySpawn").transform.position;
    }

    public void Makelevels()
    {
        levels.Add(new List<string> { "000", "0011", "10101", "00112", "222" });
        levels.Add(new List<string> { "111", "2000", "1122", "0011222", "222" , "13"});
    }

    void Update()
    {
        //listOfLists.Count > listIndex && listOfLists[listIndex].Count > gameObjectIndex
        //listOfLists[listIndex][gameObjectIndex]
        if (canSpawn)
        {
            level = levels[currentLevelIndex];
            if (currentWaveIndex <= level[currentWaveIndex].Length)
                StartCoroutine(SpawnWave());
            else Victory();
        }
        if (health < 1)
        {
            health = 0;
            Defeat();
        }
    }
    IEnumerator SpawnWave()
    {
        canSpawn = false;
        yield return new WaitForSeconds(2f);
        // 
        wave = level[currentWaveIndex];
        Debug.Log("Wave starting: " + wave);
        foreach (char i in wave)
        {
            int enemyNumber = (int)char.GetNumericValue(i);
            GameObject enemy = enemyPrefabs[enemyNumber];
            Debug.Log("enemy: " + enemy);
            EnemyInfo info = enemy.GetComponent<LiikutaObjektia>().enemyInfo;

            yield return new WaitForSeconds(info.spawnSpeed / 2);
            Instantiate(enemy, enemySpawnPos, transform.rotation);
            yield return new WaitForSeconds(info.spawnSpeed / 2);
        }
        Debug.Log("Wave loppu..");
        yield return new WaitForSeconds(3f);
        currentWaveIndex++;
        canSpawn = true;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("You took: " + damage + "damage");
        health -= damage;
        if (health <= 0)
        {
            Defeat();
        }
    }

    public void StartGame()
    {
        Debug.Log("Let the game begin");
        health = maxHealth;
        canSpawn = true;
    }

    public void Victory()
    {
        Debug.Log("Victory");
        EndMap();
    }

    public void Defeat()
    {
        Debug.Log("Defeat");
        EndMap();
    }

    public void EndMap()
    {
        canSpawn = false;
        StopCoroutine(SpawnWave());
    }
}
