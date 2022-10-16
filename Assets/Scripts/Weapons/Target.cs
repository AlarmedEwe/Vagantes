using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 10;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
