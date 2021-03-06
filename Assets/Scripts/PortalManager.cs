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

    //Mover
    public Mover mover;
    void Start()
    {
        int i=0;
        //位置を保存しておく
        _camPos=new Vector3[2];
        foreach(GameObject camera in cam){
            _camPos[0]=camera.transform.position;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Playerの移動
        mover.Move(this.gameObject);

        //Portal用カメラの同期
        //localpositionは相対座標．ポータル自体からの距離．
        
        //前に進むとは，ポータル方向に進むことである．
        Vector3 pos=playcam.transform.position-Portals[_portalIndex].transform.position;
        pos.y=playcam.transform.position.y;

            cam[_portalIndex].transform.localPosition=pos;
            
            cam[_portalIndex].transform.localRotation=playcam.transform.localRotation;


            
    }

    void OnTriggerEnter(Collider other)
    {
        //あたったのがPortalならカメラの位置へワープ
        if(other.CompareTag("portal")){
            //位置の同期
            Transform transform=this.transform;
            transform.position=cam[0].GetComponent<Transform>().position;
            transform.rotation=cam[0].GetComponent<Transform>().rotation;

            
            //camを次の奴へ更新(今回はループ)

            //更新
            //_portalIndex=(_portalIndex+1)%2;
        }
    }
}

