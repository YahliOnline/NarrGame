using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyHandler : MonoBehaviour
{
    public UnityEvent KeyPickup;
    [SerializeField] Transform playerTransform; //gets info on the player
    [SerializeField] float interactionDistance = 1;
    // Start is called before the first frame update
    void Start()
    {
        //if the event hasnt happened, start the event
        if (KeyPickup == null) KeyPickup = new UnityEvent();
        //here is the player
        playerTransform = FindObjectOfType<NewPlayerController>().transform;
        //keySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null) return;
// when the interaction distance is within range, do the event and destroy the object this script is attached to
        if (Mathf.Abs(Vector2.Distance(transform.position, playerTransform.position)) < interactionDistance){
            KeyPickup.Invoke();
            Destroy(gameObject);
        }
    }
}
