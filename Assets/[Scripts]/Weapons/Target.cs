using UnityEngine;

public class Target : MonoBehaviour, IDataPersistence
{
    public float health = 50f;

    //this is just an example btw
    public void LoadData(GameData data)
    {
        this.health = data.playerHealth;
    }

    public void SaveData(ref GameData data)
    {
        data.playerHealth = this.health;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
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