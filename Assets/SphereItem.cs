using UnityEngine;

public class SphereItem : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Автоматично шукаємо менеджер гри на сцені
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    // Спрацьовує, коли гравець забігає у сферу
    private void OnTriggerEnter(Collider other)
    {
        // Перевіряємо, чи це гравець торкнувся сфери
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
                gameManager.CollectSphere(); // Кажемо менеджеру, що сфера зібрана

            Destroy(gameObject); // Видаляємо сферу зі сцени, щоб вона зникла
        }
    }
}
