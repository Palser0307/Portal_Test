using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchroManager : MonoBehaviour
{
    //cameraの集合
    public GameObject[] cam;
    //動き
    public Mover mover;
    //playerのカメラ
    public Camera playcam;

    private int camIndex=0;

    void Start(){
        
    }
    // Update is called once per frame
    void Update()
    {
        //プレイヤの動きと同期をとるだけ
        mover.Move(cam[camIndex]);    
        cam[camIndex].transform.localRotation=playcam.transform.localRotation;

    }
}
