using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] RenderTextureCameras;
    public GameObject[] Portals;

    int _portalIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _portalIndex=0;

        foreach(var camera in RenderTextureCameras){
            //Portal用カメラの同期
            //localpositionは相対座標．ポータル自体からの距離．
            camera.transform.localPosition=transform.position-Portals[_portalIndex].transform.position;
            camera.transform.localRotation=transform.localRotation;
            _portalIndex++;
        }
    }
}
