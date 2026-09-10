using UnityEngine;
using UnityEngine.SceneManagement; // Обов'язково для роботи зі сценами

public class MonsterAttack : MonoBehaviour
{
    // Спрацьовує, коли гравець заходить у тригер монстра
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Монстр наздогнав гравця! Перехід на екран програшу.");

            // Вкажіть у лапках точну назву вашої сцени програшу
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("LoseScene");
        }
    }
}
