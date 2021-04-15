using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Cristal[] cristais; // Cristais observados pela porta os quais ela irá reagir
    public Color[] cores; // Cores que devem ser aparecer nos cristais para que a porta desapareça
    public bool habilidata; // Indica se porta ainda pode aparecer/desaparecer de acordo os cristais
    public bool desabilitarCristais; // Indica se os cristais serão desabilitados automaticamente ao resolver o puzzle

    private void Update()
    {
        if (habilidata && cristais != null && cristais.Length > 0 && cores != null && cores.Length > 0)
        {
            bool coresOK = true;

            for (int i = 0; i < cristais.Length; i++)
            {
                SpriteRenderer srCristal = cristais[i].GetComponent<SpriteRenderer>();
                if (srCristal.color != cores[i])
                {
                    coresOK = false;
                    break;
                }
            }

            if (coresOK)
                AbrirPorta();
        }
    }

    public void AbrirPorta()
    {
        if (desabilitarCristais)
            foreach (Cristal cristal in cristais)
                cristal.habilitado = false;

        gameObject.SetActive(false);
    }
}
