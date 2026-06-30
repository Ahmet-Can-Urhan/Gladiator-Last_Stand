using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "WaveTypes", menuName = "Enemy/WaveTypes")]
public class WaveTypes : ScriptableObject
{
    [SerializeField] public GameObject enemyType1;
    [SerializeField] public int type1Count;

    [SerializeField] public GameObject enemyType2;
    [SerializeField] public int type2Count;

    [SerializeField] public GameObject enemyType3;
    [SerializeField] public int type3Count;

    public float[,] spawnPositions = { { -59.81f, 14.70f, 0f }, { -90.13f,18.75f,0f}, { -96.54f, -7.59f, 0 }, { -66.7f,-10.9f,0} };
    
}
