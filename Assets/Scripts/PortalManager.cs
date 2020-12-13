using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cam;
    public GameObject[] Portals;

    //playerのカメラ
    public Camera playcam;

    //今みているポータルとポータル先をうつすカメラの番号
    private int _portalIndex=0;
    //ポータルの初期位置
    private Vector3[] _camPos;
    void Start()
    {
        int i=0;
        //位置を保存しておく
        _camPos=new Vector3[2];
        foreach(GameObject camera in cam){
            _camPos[i]=camera.transform.position;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Portal用カメラの同期
        //localpositionは相対座標．ポータル自体からの距離．
        Debug.Log(_portalIndex);
        //前に進むとは，ポータル方向に進むことである．
            cam[_portalIndex].transform.localPosition=playcam.transform.position-Portals[_portalIndex].transform.position;
            cam[_portalIndex].transform.localRotation=playcam.transform.localRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        //あたったのがPortalならカメラの位置へワープ
        if(other.CompareTag("portal")){
            this.GetComponent<Transform>().position=cam[0].GetComponent<Transform>().position;

            Debug.Log(cam[0].transform.position.x);
            Debug.Log(this.transform.position.x);
            
            //camを次の奴へ(今回はループ)
            _portalIndex=(_portalIndex+1)%2;
        }
    }
}

