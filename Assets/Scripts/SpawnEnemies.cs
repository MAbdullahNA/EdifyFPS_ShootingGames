using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform[] spwanPositons = null;
    public GameObject enemy;
    public Transform enemyParent;

    private void Start()
    {
        GenerateGO();
    }

    private void GenerateGO()
    {
        for (int i = 0; i < spwanPositons.Length; i++)
        {
            Instantiate(enemy, spwanPositons[i].position, Quaternion.identity, enemyParent);
        }
    }
}
