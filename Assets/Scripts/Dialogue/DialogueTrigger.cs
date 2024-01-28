using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;



    private void Awake(){
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update(){
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            visualCue.SetActive(true);
            
            //InputHandler.GetInstance().checkIconClicked();
            if (Input.GetMouseButtonDown(0)){
                RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
                if (rayHit.collider != null){
                InputHandler.GetInstance().checkIconClicked(rayHit, inkJSON);
                }
            }
            
        } else {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player"){
            playerInRange = false;
        }
    }
}
