using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameButton : MonoBehaviour
{
    public void MudaCena()
    {
        SceneManager.LoadScene("Start");
    }
}
