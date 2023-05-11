using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        UnlockMouse();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuiteGame()
    {
        Debug.Log("Game has quit!");
        Application.Quit();
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
