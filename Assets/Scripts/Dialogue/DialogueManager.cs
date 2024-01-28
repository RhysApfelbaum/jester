using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;}

    private static DialogueManager instance;

    private void Awake(){
        if (instance != null){
            Debug.LogWarning("Found more than one Dialogue Manager in the scene ");
        }
        instance = this;
    }

    public static DialogueManager GetInstance(){
        return instance;
    }

    private void Start(){
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update(){
        
        if (!dialogueIsPlaying){
            return;
        }

        // continue to the next line in the dialogue when submit is pressed
        if (Input.GetMouseButtonDown(0)){
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode(){
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    public void ContinueStory(){
        if (currentStory.canContinue){
            dialogueText.text = currentStory.Continue();

        } else {
            ExitDialogueMode();
        }
    }
}
