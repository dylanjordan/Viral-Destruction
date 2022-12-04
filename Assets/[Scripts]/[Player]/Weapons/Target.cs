using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    //this is just an example btw

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log(health);
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}