using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public static MusicHandler instance;
    void Awake(){
        if (instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
