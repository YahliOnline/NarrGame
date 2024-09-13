using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewPlayerController : MonoBehaviour
{
    private bool moveLeft, moveRight, moveUp, moveDown;
    [SerializeField] Vector2 playerPosition, originalPosition;
    [SerializeField] Vector2 playerSize;
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start(){
        //i belive these two lines of code determine the players starting position
        playerPosition = gameObject.transform.position;
        originalPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //run the process input and then set the playerPosition to the new position
        ProcessInput();
        transform.position = playerPosition;
    }
    //the process input function is used to say if a key is pressed, move the player in a certain direction at a certain speed multiplied by time
    void ProcessInput(){
        if (Input.GetKey(KeyCode.LeftArrow)){
            playerPosition.x -= moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow)){
            playerPosition.x += moveSpeed * Time.deltaTime;
        } 

        if (Input.GetKey(KeyCode.UpArrow)){
            playerPosition.y += moveSpeed * Time.deltaTime;
        } 

        if (Input.GetKey(KeyCode.DownArrow)){
            playerPosition.y -= moveSpeed * Time.deltaTime;
        } 
    }
    bool CanMove(){
        if (Physics2D.BoxCast(transform.position, playerSize, 0, playerPosition, playerPosition.magnitude)){
            return false;
        }
        return true;
    }
}