using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void GoToRestart()
    {
        int valorCena = PlayerPrefs.GetInt("previousLevel");
        SceneManager.LoadScene(valorCena);
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
