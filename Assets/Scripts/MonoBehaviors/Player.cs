using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Caractere
{
    public Inventario inventarioPrefab; // referência ao objeto prefab criado do Inventário
    Inventario inventario; // referência ao Inventário

    public HealthBar healthBarPrefab; // referência ao objeto prefab criado da HealthBar
    HealthBar healthBar; // referência à HealthBar

    public PontosDano pontosDano; // novo tipo que tem o valor da "saúde" do objeto script

    public GameObject Destino;    // referência ao objeto que define a posição de destino do teleporte

    private void Start()
    {
        inventario = Instantiate(inventarioPrefab);

        pontosDano.valor = InicioPontosDano;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)  //Define comportamento ao jogador colidir com não-inimigos
    {
        if (collision.gameObject.CompareTag("Coletavel"))   // Objetos coletáveis para o iventário
        {
            Item danoObjeto = collision.gameObject.GetComponent<Consumable>().item;
            if (danoObjeto != null)
            {
                bool deveDesaparecer = false;
                //print("Acertou: " + danoObjeto.nomeObjeto);

                switch (danoObjeto.tipoItem)
                {
                    case Item.TipoItem.CHAVE:
                        deveDesaparecer = inventario.AddItem(danoObjeto);
                        break;
                    case Item.TipoItem.MUNICAO:
                        for(int i=0;  i< danoObjeto.quantidade; i++)
                        {
                            deveDesaparecer = inventario.AddItem(danoObjeto);
                        }
                        break;
                    case Item.TipoItem.POÇÃO:
                        deveDesaparecer = AjustarPontosDano(danoObjeto.quantidade);
                        break;

                    default:
                        break;
                }

                if (deveDesaparecer)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
        // Verificação de colisão com Porta e se o Player possui chaves (Lucas Ferraz Nicolau)
        else if (collision.gameObject.CompareTag("Porta"))
        {
            Porta porta = collision.gameObject.GetComponent<Porta>();
            if (porta.tipoPorta == Porta.TipoPorta.CHAVE)
                if (inventario.RemoveItem("CHAVE"))
                    porta.AbrirPorta();
        }
        else if (collision.gameObject.CompareTag("TeleporteBoss")) // Faz acontecer o teleporte na área necessária
        {
            Destino = GameObject.Find("TeleportDestino");
            transform.position = Destino.transform.position;
        }
    }

    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickerCaractere());

            pontosDano.valor -= dano;

            if (pontosDano.valor <= float.Epsilon)
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

    public override void KillCaractere()
    {
        base.KillCaractere();
        Destroy(healthBar.gameObject);
        Destroy(inventario.gameObject);
        int indexCena = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("previousLevel", indexCena);
        SceneManager.LoadScene("Game_Over");
    }

    public override void ResetCaractere()
    {
        inventario = Instantiate(inventarioPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
        pontosDano.valor = InicioPontosDano;
    }

    /// <summary>
    /// Método que recupera os pontos de dano (saúde) do player
    /// </summary>
    /// <param name="quantidade">Quantidade de pontos de vida recebida</param>
    /// <returns>Retorna se a quantidade de vida foi aumentada, isto é, se já não estava no máximo</returns>
    public bool AjustarPontosDano(int quantidade)
    {
        if (pontosDano.valor < MaxPontosDano)
        {
            pontosDano.valor += quantidade;
            print("Ajustando Pontos de Dano por: " + quantidade + ". Novo valor: " + pontosDano.valor);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool verificaMunicao()                   // metodo que verifica se o player possui munição
    {
        if (inventario.removeMunicao() == true)
        {
            return true;
        }
        return false;
    }

}
