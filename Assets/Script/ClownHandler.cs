using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClownHandler : MonoBehaviour
{
    private bool moveLeft;
    [SerializeField] float leftWall;
    [SerializeField] float rightWall;
    [SerializeField] Vector2 clownPosition;
    [SerializeField] float clownSpeed;
    [SerializeField] float clownY;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<NewPlayerController>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        WallTouch();
        if (moveLeft){
            clownPosition.x -= clownSpeed * Time.deltaTime;
            clownPosition.y = clownY;
        }
        else{
            clownPosition.x += clownSpeed * Time.deltaTime;
            clownPosition.y = clownY;
        }
        transform.position = clownPosition;
        WinCon();
    }
    void WallTouch(){
        if (clownPosition.x < leftWall){
            moveLeft = false;
        }
        else if (clownPosition.x > rightWall){
            moveLeft = true;
        }
    }
    void WinCon(){
        if (Mathf.Abs(Vector2.Distance(playerTransform.position, transform.position)) < 1){
            SceneManager.LoadScene("Scene3");
        }
    }
}
