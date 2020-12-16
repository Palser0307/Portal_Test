using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private void Update()
    {



        // 前後への移動
        var v = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
        var c = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
       
        Vector3 velocity = new Vector3(c, 0, v);
                
        
        velocity.Normalize();
        velocity=transform.TransformDirection(velocity);
        velocity *= 5f;
        transform.localPosition += velocity * Time.fixedDeltaTime;

                // 左右への方向転換
        var h = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
        transform.Rotate(0, h * 3f, 0);
    }
}

