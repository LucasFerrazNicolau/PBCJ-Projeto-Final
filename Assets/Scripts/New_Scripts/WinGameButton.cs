using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameButton : MonoBehaviour
{
    public void MudaCena()              // metodo que muda a cena conforme o bot�o �� pressioando
    {
        SceneManager.LoadScene("Start");
    }
}
