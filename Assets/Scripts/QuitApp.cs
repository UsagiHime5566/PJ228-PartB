using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitApp : MonoBehaviour
{
    public int count = 0;
    public int affectCount = 5;
    public Button BTNQuit;
    void Start()
    {
        BTNQuit.onClick.AddListener(DoCountQuit);
    }

    void DoCountQuit(){
        count++;

        if(count > affectCount)
            Application.Quit();
    }
}
