using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCena : MonoBehaviour
{
    public int indexCena = 0;

    private void OnTriggerEnter2D(Collider2D collision)         // metodo que verifica quando entra em colisão com player
    {
        if (collision.gameObject.tag == "Player")
        {
            mudaCena();
        }
    }


    public void mudaCena()                  //muda a cena com base no index
    {
        SceneManager.LoadScene(indexCena);
    }
}
