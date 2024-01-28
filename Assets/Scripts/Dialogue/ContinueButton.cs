using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public Button continueButton;

    private void Start(){
        continueButton.onClick.AddListener(ContinueDialogue);
    }

    private void ContinueDialogue(){
        DialogueManager.GetInstance().ContinueStory();
    }

    
}
