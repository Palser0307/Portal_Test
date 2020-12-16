using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Move manager")]
    public Mover manager;
    [Header("Move Objects by Controller")]
    public GameObject[] mover;

    // Update is called once per frame
    void Update()
    {
        //コントローラで動いてほしいやつはここで動かす
        foreach(GameObject obj in mover){
            manager.Move(obj);
        }
       
    }
}
