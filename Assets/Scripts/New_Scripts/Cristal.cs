using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]

// Classe criada e gerenciada por Lucas Ferraz Nicolau
public class Cristal : MonoBehaviour
{
    public Color[] cores; // Poss�veis cores do cristal
    public Color corInicial; // Cor com a qual o cristal ir� iniciar
    public bool interruptor; // Indica se o cristal funciona como um interruptor alterando apenas entre a cor inicial e a primeira cor da lista
    public bool habilitado; // Indica se o cristal ainda pode mudar de cor

    int indiceCorAtual; // Indica o �ndice da cor na qual o cristal se encontra no momento. � inicializado como -1.

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

    /// <summary>
    /// Aplica a l�gica de troca de cor ao cristal
    /// </summary>
    public void TrocarCor()
    {
        if (habilitado && cores != null && cores.Length > 0)
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
