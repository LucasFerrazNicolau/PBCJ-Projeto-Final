using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]

public class Cristal : MonoBehaviour
{
    public Color[] cores; // Possíveis cores do cristal
    public Color corInicial; // Cor com a qual o cristal irá iniciar
    public bool interruptor; // Indica se o cristal funciona como um interruptor alterando apenas entre a cor inicial e a primeira cor da lista
    public bool habilitado; // Indica se o cristal ainda pode mudar de cor

    int indiceCorAtual; // Indica o índice da cor na qual o cristal se encontra no momento. É inicializado como -1.

    SpriteRenderer sr; // Armazena componente SpriteRenderer do objeto

    private void Awake()
    {
        indiceCorAtual = -1;

        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        sr.color = corInicial;
    }

    public void TrocarCor()
    {
        if (habilitado)
        {
            if (interruptor)
            {
                if (sr.color == corInicial)
                    sr.color = cores[0];
                else
                    sr.color = corInicial;
            }
            else
            {
                if (indiceCorAtual < 0 || indiceCorAtual == cores.Length - 1)
                    indiceCorAtual = 0;
                else
                    indiceCorAtual++;

                sr.color = cores[indiceCorAtual];
            }
        }
    }
}
