using System.Collections;
using UnityEngine;

public class Inimigo : Caractere
{
    float pontosVida; // equivalente a saúde do inimigo

    public int forcaDano; // poder de dano do inimigo
    Coroutine danoCoroutine;

    public AudioSource playerHitSource; // nova fonte de audio para o acerto do inimigo
    public GameObject audioSource; // Referencia ao objeto do tipo audio source na cena

    private void OnEnable()
    {
        ResetCaractere();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource = GameObject.Find("Audio Source 2"); // Localiza o objeto audio source 2
        playerHitSource = audioSource.GetComponent<AudioSource>(); // liga o componente do objeto à fonte de audio

        if (collision.gameObject.CompareTag("Player"))
        {
            playerHitSource.Play(); //toca o audio de jogador atingido

            Player player = collision.gameObject.GetComponent<Player>();

            if (danoCoroutine == null)
            {
                danoCoroutine = StartCoroutine(player.DanoCaractere(forcaDano, 1.0f));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (danoCoroutine != null)
            {
                StopCoroutine(danoCoroutine);
                danoCoroutine = null;
            }
        }
    }

    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickerCaractere());

            pontosVida -= dano;

            if (pontosVida <= float.Epsilon)
            {
                KillCaractere();
                break;
            }

            if (intervalo > float.Epsilon)
            {
                yield return new WaitForSeconds(intervalo);
            }
            else
            {
                break;
            }
        }
    }

    public override void ResetCaractere()
    {
        pontosVida = InicioPontosDano;
    }
}
