using UnityEngine;

public class Municao : MonoBehaviour
{
    public int danoCausado; // Poder de dano da munição
    //public AudioClip hit;
    public AudioSource enemyHitSource;
    public GameObject audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource = GameObject.Find("Audio Source");
        enemyHitSource = audioSource.GetComponent<AudioSource>();
        if (collision is BoxCollider2D)
        {
            if (collision.gameObject.CompareTag("Inimigo"))
            {
                /*AudioSource hitprefab = GetComponent<AudioSource>();
                hitprefab.clip = hit;
                hitprefab.Play();*/
                //Debug.Log("atingiu inimigo");
                enemyHitSource.Play();
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
