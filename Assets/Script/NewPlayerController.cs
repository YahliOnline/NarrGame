using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewPlayerController : MonoBehaviour
{
    private bool moveLeft, moveRight, moveUp, moveDown;
    [SerializeField] Vector2 playerPosition, originalPosition;
    [SerializeField] Vector2 playerSize;
    [SerializeField] float moveSpeed;
    public LayerMask wallLayer;
    [SerializeField] Animator playerAnimator;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start(){
        //i believe these two lines of code determine the players starting position
        playerPosition = gameObject.transform.position;
        originalPosition = new Vector2(transform.position.x, transform.position.y);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimator.SetBool("isWalk", false);
        //run the process input and then set the playerPosition to the new position
        ProcessInput();
        ApplyMovement();

    }
    //the process input function is used to say if a key is pressed, move the player in a certain direction at a certain speed multiplied by time
    void ProcessInput()
    {

        // every frame we want to create a movement we're proposing, check if it is free, and then move if that position is free.
        Vector2 proposedMovement = playerPosition;

        if (Input.GetKey(KeyCode.LeftArrow)){
            proposedMovement.x -= moveSpeed * Time.deltaTime;
            //gameObject.transform.localScale = new Vector3(1, 1, 1);  
            spriteRenderer.flipX = false;
            playerAnimator.SetBool("isWalk", true);

        }

        if (Input.GetKey(KeyCode.RightArrow)){
            proposedMovement.x += moveSpeed * Time.deltaTime;   
            //gameObject.transform.localScale = new Vector3(-1, 1, 1); 
            spriteRenderer.flipX = true; 
            playerAnimator.SetBool("isWalk", true);    
        } 

        if (Input.GetKey(KeyCode.UpArrow)){         
            proposedMovement.y += moveSpeed * Time.deltaTime;
            playerAnimator.SetBool("isWalk", true); 
        } 

        if (Input.GetKey(KeyCode.DownArrow)){        
            proposedMovement.y -= moveSpeed * Time.deltaTime;
            playerAnimator.SetBool("isWalk", true); 
        } 

        // then we want to run a function which checks the proposed movement that we want to move our player with
        if (CanMove(proposedMovement))
        {
            playerPosition = proposedMovement;
        }

    }

    // determines whether or not there is an unblocked movement between the player's position and the desired position
    bool CanMove(Vector2 proposedPosition)
    {
        // do a linecast from our current position to the player's proposed movement
        return !Physics2D.Linecast(playerPosition, proposedPosition);
    }

    void ApplyMovement(){
        transform.position = playerPosition;
    }
}