using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Defeat();
        }
    }

    void Defeat()
    {
        Destroy(gameObject);
    }

}
