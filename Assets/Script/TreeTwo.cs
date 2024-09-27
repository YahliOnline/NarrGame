using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeTwo : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<NewPlayerController>().transform; //like the key script, checks for where the player is
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(playerTransform.position, transform.position) < 2){
            SceneManager.LoadScene("Scene3");
        }
    }
}
