using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
    [SerializeField] float interactionDistance; //how close do we need to be to have the NPC talk
    [SerializeField] string currentWords, words, newWords; //what the NPC is saying, and what the new dialogue is
    [SerializeField] TextMeshProUGUI wordText; //the words
    [SerializeField] GameObject textParent; //NOT SURE WHY WE NEED THIS, but its the parent object of our text
    //[SerializeField] KeyHandler keyHandler; //the handler for the key, which I dont have programmed yet
    bool isTalking; //are we talking?
    Transform playerTransform; //I'm guessing this is to know where the player is, will probably determine interactionDistance

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform; //gets the players transform for the ProcessCheckTalk function
        //keyHandler = FindObjectOfType<KeyHandler>();
        //keyHandler.KeyPickup.AddListener(UpdateText);
        currentWords = words; //this is setting up dialogue
    }

    // Update is called once per frame
    void Update() //I'm using regular update but Josh used FixedUpdate, not sure why, I think FixedUpdate is used for physics so I'm going to fuck around and find out
    {
        ProcessCheckTalk();
    }

    IEnumerator ProcessTalk(){ 
    //I believe this function checks to see if the NPC is talking, then sets the text to the current text, then once its active counts down 5 seconds and shuts off the parent to the text.
        isTalking = true;
        wordText.text = currentWords;
        textParent.SetActive(true);
        yield return new WaitForSeconds(5);
        textParent.SetActive(false);
        isTalking = false;
    }

    void ProcessCheckTalk(){
    //apparently this run every frame to check if the NPC can talk, sounds inneficient?
        if ((Input.GetKey(KeyCode.Space)) && Mathf.Abs(Vector2.Distance(playerTransform.position, transform.position)) < interactionDistance && !isTalking){
            StartCoroutine(ProcessTalk());
        }    
    }

    void UpdateText(){
        //update if key has been picked up
        currentWords = newWords;
    }
}
