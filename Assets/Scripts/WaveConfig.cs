using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWaveConfig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    [SerializeField] float spawnRandomFactor;
    [SerializeField] int numberOfEnemy = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetenemyPrefab()
    {
        return enemyPrefab;
    }
    public List<Transform> GetWayPoints()
    {
        var WaveWayPoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            WaveWayPoints.Add(child);
        }
        return WaveWayPoints;
    }
    public float GettimeBetweenSpwan()
    {
        return timeBetweenSpawn;
    }
    public float GetspawnRandomFactor()
    {
        return spawnRandomFactor;
    }
    public int GetnumberOfEnemy()
    {
        return numberOfEnemy;
    }
    public float GetmoveSpeed()
    {
        return moveSpeed;
    }
    
}
