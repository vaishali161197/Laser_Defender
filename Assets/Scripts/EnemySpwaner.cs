using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;
    [SerializeField] bool looping = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(spwanAllWaves());
        }
        while (looping);
    }
    private IEnumerator spwanAllWaves() //this function is used to create multiple wave and move enemy on that wave
    {
        for(int waveIndex= startingWave; waveIndex<waveConfigs.Count; waveIndex++)// used to create multiple wave 
        {
            var currentWave = waveConfigs[waveIndex];
           yield return  StartCoroutine(spwanAllEnemiesInWave(currentWave));
        }
    }

    // Update is called once per frame
    
    private IEnumerator spwanAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetnumberOfEnemy(); i++)
        {
           var newEnemy = Instantiate(waveConfig.GetenemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GettimeBetweenSpwan());
        }
    }
}
