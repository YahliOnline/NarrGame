using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    [SerializeField] Transform playerTransform; //gets info on the player
    [SerializeField] float interactionDistance = 1.0001f;
    private AudioSource audioSource;
    bool hasPlayed = true;
    // Start is called before the first frame update
    void Start()
    {
        //here is the player
        playerTransform = FindObjectOfType<NewPlayerController>().transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null) return;
// when the interaction distance is within range, do the event and destroy the object this script is attached to
        if (hasPlayed ==true && Mathf.Abs(Vector2.Distance(transform.position, playerTransform.position)) < interactionDistance){
            audioSource.Play();
            hasPlayed = false;
        }
    }
}
