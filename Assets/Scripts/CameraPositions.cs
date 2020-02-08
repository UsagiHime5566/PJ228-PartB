using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraPositions : MonoBehaviour
{
    public float baseX_pos = 26.66666f;
    public Scene CameraScene;
    public enum Scene {
        S0,
        S1,
        S2,
        S3,
    }

    public Button ToLeft;
    public Button ToRight;
    public float CameraMoveTime = 1.0f;
    void Start()
    {
        ToLeft.onClick.AddListener(BTNLeft);
        ToRight.onClick.AddListener(BTNRight);
        ArrowUpdate();
    }

    void ArrowUpdate(){
        if(CameraScene == Scene.S3){
            ToLeft.gameObject.SetActive(false);
        } else {
            ToLeft.gameObject.SetActive(true);
        }
        if(CameraScene == Scene.S0){
            ToRight.gameObject.SetActive(false);
        } else {
            ToRight.gameObject.SetActive(true);
        }
    }

    void MovingCamera(){
        int pos = (int)CameraScene;
        Vector3 newPos = new Vector3(baseX_pos + pos * -17.7777f, 0, -10);
        transform.DOLocalMove(newPos, CameraMoveTime).OnComplete(()=>{
            ArrowUpdate();
        });
    }

    void SceneSwitch(int dir){
        if(dir > 0){
            if((int)CameraScene > 0)
                CameraScene = (Scene)((int)CameraScene - 1);
        } else {
            if((int)CameraScene < (int)Scene.S3)
                CameraScene = (Scene)((int)CameraScene + 1);
        }

        MovingCamera();
    }

    void BTNLeft(){
        SceneSwitch(-1);
    }

    void BTNRight(){
        SceneSwitch(1);
    }

    void OnValidate() {
        //MovingCamera();
        int pos = (int)CameraScene;
        transform.position = new Vector3(baseX_pos + pos * -17.7777f, 0, -10);
    }
}
