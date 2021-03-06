using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseManager : MonoBehaviour
{

    public  GameObject  start;              // Game object do painel default
    public  GameObject  phaseSelector;      // Game object do painel Phase_select
    public  GameObject  options;            // Game object do painel Options
    public GameObject title;            // Game object do painel Titulo
    public bool isInTitle = false;

    // Start is called before the first frame update
    void Start()
    {
        isInTitle = true;
        title = GameObject.Find("TitleScreen");
        start = GameObject.Find("Default");
        start.SetActive(false);
        phaseSelector = GameObject.Find("Phases");
        phaseSelector.SetActive(false);
        options = GameObject.Find("Options");
        options.SetActive(false);
    }
    void Update()
    {
        if (Input.anyKeyDown && isInTitle == true)
        {                                         // qualquer tecla pressionada ira carregar o menu principal
            isInTitle = false;
            title.SetActive(false);
            Comeco();
        }
    }


    public void Fases() {                   // Desativa o painel start e ativa o phaseSelector
        start.SetActive(false);
        phaseSelector.SetActive(true);
    }

    public void Comeco() {                  // Deixa s? o painel start ativo
        start.SetActive(true);
        title.SetActive(false);
        phaseSelector.SetActive(false);
        options.SetActive(false);
    }

    public void Options() {                 // Desativa o painel start e ativa o options
        start.SetActive(false);
        options.SetActive(true);
    }

    public void Exit() {                    // Fecha o jogo
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }

    public void Fase1() {                   // Carrega a fase 1
        SceneManager.LoadScene("Lab5_RPG_Cena01");
    }

    public void Fase2() {                   // Carrega a fase 2
        SceneManager.LoadScene("Phase_2");
    }

    public void Fase3() {                   // Carrega a fase 3
        SceneManager.LoadScene("Phase_3");
    }

    public void Creditos() {                   // Carrega a fase Creditos
        SceneManager.LoadScene("Credits");
    }
    public void MenuPrincipal()
    {                                          // Alternativa para voltar ao menu principal
        SceneManager.LoadScene("Start");
    }

    public void Resolucao1280x720() {               // Seta a resolu??o em 1280x720
        Screen.SetResolution(1280, 720, true);
    }

    public void Resolucao1920x1080() {              // Seta a resolu??o em 1920x1080
        Screen.SetResolution(1920, 1080, true);
    }

    public void Resolucao800x600() {                // Seta a resolu??o em 800x600
        Screen.SetResolution(800, 600, true);
    }

    public void Resolucao1366x768() {               // Seta a resolu??o em 1366x768
        Screen.SetResolution(1366, 768, true);
    }
}
