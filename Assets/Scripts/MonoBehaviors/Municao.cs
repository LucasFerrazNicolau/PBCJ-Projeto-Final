using UnityEngine;

public class Municao : MonoBehaviour
{
    public int danoCausado; // Poder de dano da munição
    public AudioSource enemyHitSource; // nova fonte de audio para o acerto no inimigo
    public GameObject audioSource; // Referencia ao objeto audio source na cena

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource = GameObject.Find("Audio Source"); // Localiza o objeto audio source
        enemyHitSource = audioSource.GetComponent<AudioSource>(); // liga o componente do objeto à fonte de audio
        if (collision is BoxCollider2D)
        {
            if (collision.gameObject.CompareTag("Inimigo"))
            {
                enemyHitSource.Play();   //toca o audio de atingir inimigo
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
