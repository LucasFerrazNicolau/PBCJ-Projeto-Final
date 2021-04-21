using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCena : MonoBehaviour
{
    public int indexCena = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mudaCena();
        }
    }


    public void mudaCena()
    {
        SceneManager.LoadScene(indexCena);
    }
}
