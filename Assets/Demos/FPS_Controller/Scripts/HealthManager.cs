using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float health = 100f;


    private void Start()
    {
        health = Random.Range(50, 101);
    }
    public void UpdateHealth(float value)
    {
        health += value;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
