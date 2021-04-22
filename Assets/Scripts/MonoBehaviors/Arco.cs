using System.Collections;
using UnityEngine;

public class Arco : MonoBehaviour
{
    public IEnumerator ArcoTrajetoria(Vector3 destino, float duracao)
    {
        var posicaoInicial = transform.position;
        var percentualCompleto = 0.0f;

        // Rotação da munição de acordo posição de estino (Lucas Ferraz Nicolau)
        Vector3 direction = destino - posicaoInicial;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        while (percentualCompleto < 1.0f)
        {
            percentualCompleto += Time.deltaTime / duracao;
            //var alturaCorrente = Mathf.Sin(Mathf.PI * percentualCompleto);
            //transform.position = Vector3.Lerp(posicaoInicial, destino, percentualCompleto) + Vector3.up * alturaCorrente;
            transform.position = Vector3.Lerp(posicaoInicial, destino, percentualCompleto);
            percentualCompleto += Time.deltaTime / duracao;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
