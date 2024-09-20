using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    KeyHandler keyHandler; // the handler for the key
    DoorHandler doorHandler; // our door handler
    AudioSource source;
    [SerializeField] AudioClip door, key;

    private void Start()
    {
        // get our key handler
        keyHandler = FindObjectOfType<KeyHandler>();
        keyHandler.KeyPickup.AddListener(() => { source.clip = key; source.Play(); Debug.Log("fired"); });
        doorHandler = FindAnyObjectByType<DoorHandler>();
        doorHandler.doorOpen.AddListener(() => { source.clip = door; source.Play(); Debug.Log("fired");  });
    }
}
