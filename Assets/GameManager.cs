using UnityEngine;
using UnityEngine.SceneManagement; // Потрібно для перемикання сцен

public class GameManager : MonoBehaviour
{
    public int totalSpheresNeeded = 5; 
    private int currentSpheresCollected = 0; 

   
    public void CollectSphere()
    {
        currentSpheresCollected++;
        Debug.Log("Сферу зібрано! Всього: " + currentSpheresCollected + " з " + totalSpheresNeeded);

       
        if (currentSpheresCollected >= totalSpheresNeeded)
            WinGame();
    }

    void WinGame()
    {
        Debug.Log("Ви виграли! Перехід на  сцену.");

     
        SceneManager.LoadScene("WinScene");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }


}
