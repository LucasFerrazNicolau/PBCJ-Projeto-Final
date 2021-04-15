using UnityEngine;

public class Municao : MonoBehaviour
{
    public int danoCausado; // Poder de dano da munição

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            if (collision.gameObject.CompareTag("Inimigo"))
            {
                Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();
                StartCoroutine(inimigo.DanoCaractere(danoCausado, 0.0f));
                gameObject.SetActive(false);
            }

            if (collision.gameObject.CompareTag("Cristal"))
            {
                Cristal cristal = collision.gameObject.GetComponent<Cristal>();
                cristal.TrocarCor();
            }
        }
    }
}
