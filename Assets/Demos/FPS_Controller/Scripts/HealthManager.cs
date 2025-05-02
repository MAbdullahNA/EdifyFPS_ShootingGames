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

        if (health <= 0)
        {
            if (GetComponent<Animator>())
            {
                GetComponent<Animator>().enabled = false;
                Destroy(gameObject,3);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
