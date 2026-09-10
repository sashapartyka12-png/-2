using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Викликайте цю функцію ТОДІ, коли гравець програв або виграв!
    // Вона увімкне мишку, щоб можна було клікати по кнопках.
    public void EnableMouseCursor()
    {
        Cursor.visible = true; // Робимо мишку видимою
        Cursor.lockState = CursorLockMode.None; // Розблоковуємо її, щоб вона рухалася
    }

    // Кнопка PLAY — запускає сцену "game"
    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

    // Кнопка AGAIN — перезапускає сцену "game"
    public void RestartGame()
    {
        // Перед перезапуском про всяк випадок теж звільняємо мишку
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene("game");
    }

    // Кнопка EXIT — повертає на початкову сцену
    public void ExitToMainMenu()
    {
        // При поверненні в меню мишка обов'язково має бути visible!
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene("MainMenu");
    }
}
