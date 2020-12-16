using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float movespeed=5;
    public  float rotatespeed=2;
    private float movex=0;
    private float movey=0;
    private float rot=0;
    private void Update()
    {
        // 前後への移動
        movey = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
        movex = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
        rot = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
    }

    public void Move(GameObject go){
        Transform transform;
        transform=go.transform;
                //xz平面なので．
        Vector3 velocity = new Vector3(movex, 0, movey);
                
       
        velocity.Normalize();
        //座標軸をローカルに合わせて，ワールド座標へ変換
        velocity=transform.TransformDirection(velocity);
        velocity *= movespeed;
        transform.localPosition += velocity * Time.fixedDeltaTime;

                         // 左右への方向転換
        transform.Rotate(0, rot * rotatespeed, 0);
    }
}

