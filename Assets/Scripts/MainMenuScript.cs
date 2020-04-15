using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
