using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveTypes[] waveTypes;
    private WaveTypes currentWaveType;
    public int totalEnemyCount { get; private set; }
    private int deadEnemyCount = 0;

    private WaveHandler waveHandler;

    private void Awake()
    {
        waveHandler = GetComponent<WaveHandler>();

    }

    private void Start() 
    {
        SpawnWave(waveHandler.currentWave);
    }


    public void enemyDead() 
    { 
        deadEnemyCount++;
        if (deadEnemyCount == totalEnemyCount)
        {
            deadEnemyCount = 0;
            waveHandler.OnAllWaveDead();
        }
    }
    public void SpawnWave(int waveIndex)  
    {
        currentWaveType = waveTypes[waveIndex];
        totalEnemyCount = waveTypes[waveIndex].type1Count + waveTypes[waveIndex].type2Count + waveTypes[waveIndex].type3Count;
        for (int i = 0; i < totalEnemyCount; i++) 
        {
            GameObject enemyToSpawn = null;
            if (i < currentWaveType.type1Count)
            {
                enemyToSpawn = currentWaveType.enemyType1;
            }
            else if (i < currentWaveType.type1Count + currentWaveType.type2Count)
            {
                enemyToSpawn = currentWaveType.enemyType2;
            }
            else
            {
                enemyToSpawn = currentWaveType.enemyType3;
            }
            int spawnIndex = Random.Range(0, currentWaveType.spawnPositions.GetLength(0));
            Vector2 spawnPosition = new Vector2(
                currentWaveType.spawnPositions[spawnIndex, 0],
                currentWaveType.spawnPositions[spawnIndex, 1]
            );
            Instantiate(enemyToSpawn, spawnPosition,Quaternion.identity);
        }
    
    }
}
