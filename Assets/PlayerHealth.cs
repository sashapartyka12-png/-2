using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Гравець отримав шкоду! HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Гравець загинув! Перезавантаження сцени...");

      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
