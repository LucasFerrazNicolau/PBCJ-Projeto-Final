using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {                                         // qualquer tecla pressionada ira carregar o menu principal
            MenuPrincipal();
        }
    }

    public void MenuPrincipal() {                                          // Alternativa para voltar ao menu principal
        SceneManager.LoadScene("Start");
    }
}
