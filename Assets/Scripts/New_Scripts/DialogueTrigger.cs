using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public  Dialogue    dialogue;           // guarda o dialogo a ser usado

    private void Update() {
        
    }

    private void Start() {
        TriggerDialogue();                  // chama a função q inicia o dialogo
    }   

    public void TriggerDialogue() {         // inicia o dialogo passando o dialogo a ser apresentado
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
    }
}
