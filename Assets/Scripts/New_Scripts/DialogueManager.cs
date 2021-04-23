using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText, dialogueText;
    public GameObject painel;

    public  Queue<string>   senteces;           // frases do dialogo

    // Start is called before the first frame update
    void Start()
    {
        senteces = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue) {                 // começa o dialogo
        Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;                              // seta o nome do dialogo
        painel.SetActive(true);                                     // ativa o dialogo

        senteces.Clear();

        foreach(string sentence in dialogue.sentences) {            // carrega as frases
            senteces.Enqueue(sentence);
        }

        DisplayNextSentence();                                      // apresenta a primeira frase
    }

    public void DisplayNextSentence() {                             // mostra a proxima frase
        if(senteces.Count == 0) {
            painel.SetActive(false);                                // desativa o painel se acabar o dialogo
            return;
        }

        string sentence = senteces.Dequeue();                       // carrega a proxima frase
        Debug.Log(sentence);
        dialogueText.text = sentence;                               // adiciona a proxima frase no painel
    }

    void EndDialogue() {                                            // encerra o dialogo e carrega a cena vitoria
        painel.SetActive(false);
        Debug.Log("Finish");
        SceneManager.LoadScene("Win_Game");
    }

    


}
