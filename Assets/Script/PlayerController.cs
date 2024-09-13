using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement input vector, and our movement vector
    [SerializeField] Vector2 input, move; 
    [SerializeField] float moveSpeed; //movement speed
    [SerializeField] Vector2 playerSize; // the size of our player in world space

    // Update is called once per frame
    private void FixedUpdate()
    {
        ProcessInput();
        //Move();

    }
    //turns key presses into the input vector and the move vector
    void ProcessInput(){
        input = Vector2.zero; //reset input before calculating
    //turn keys into inputs
        if (Input.GetKey(KeyCode.W)){
            input.y += 1;
        }
        if (Input.GetKey(KeyCode.S)){
            input.y -= 1;
        }
        if (Input.GetKey(KeyCode.D)){
            input.x += 1;
        }
        if (Input.GetKey(KeyCode.A)){
            input.x -= 1;
        }

        //normalize input before we use it (not sure what normalize means)
        if (input.x + input.y > 1){
            input *= 0.5f;
        }
        //after the vector is processed do the calculation for the movement vector
        move = input;
        move *=moveSpeed;
        move *= Time.deltaTime;

    }
    // Checks the move vector to see if we are able to move to that position

    bool CanMove(){
        // then check to see if there is anything at that point
        if (Physics2D.BoxCast(transform.position, playerSize, 0, input, input.magnitude * moveSpeed))
        {
            Debug.Log("can't move!");
            return false;
        }

        Debug.Log("can move");
        return true;
    }
    void Move(Vector3 targetPos){
    //in this case we are moving the player from its current position to the new position over a period of time
        //isMoving = true; 
        if (CanMove()){
            Debug.Log("applying movement");
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
             //the player gets moved to the target position
        //isMoving = false;
    }
}
