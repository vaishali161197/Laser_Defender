using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
     WaveConfig waveConfig;
     List<Transform> WayPoints;
    
    int WayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        WayPoints = waveConfig.GetWayPoints();
        transform.position = WayPoints[WayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    private void Move()
    {
        if(WayPointIndex <= WayPoints.Count -1)
        {
            var targetPosition = WayPoints[WayPointIndex].transform.position;
            var speed = waveConfig.GetmoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);

            if(transform.position == targetPosition)
            {
                WayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
