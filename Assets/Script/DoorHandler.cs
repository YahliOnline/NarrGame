using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] KeyHandler keyHandler;
    [SerializeField] GameObject door;
    public bool canOpen;
    Transform playerTransform;
    public UnityEvent doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<NewPlayerController>().transform;
        keyHandler = FindObjectOfType<KeyHandler>();
        keyHandler.KeyPickup.AddListener(UpdateDoor);
        if (doorOpen == null) doorOpen = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        openDoor();
    }

    void openDoor(){
        if (canOpen == true && Mathf.Abs(Vector2.Distance(playerTransform.position, transform.position)) < 1){
            doorOpen.Invoke();
            Destroy(gameObject);
        }
    }
    void UpdateDoor(){
        canOpen = true;
    }
}
