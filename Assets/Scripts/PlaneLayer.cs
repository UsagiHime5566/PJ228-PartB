using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlaneLayer : CanvasGroupExtend
{
    public static PlaneLayer instance;
    public Button MaskPanel;
    public Button BTNClose;
    public Button BTNNext;
    public Image Content;
    public Action OnClickObject;

    CanvasGroup canvasGroup;
    ClickData currentData;
    int currentPage;
    void Awake() {
        instance = this;
        ClickableObject.OnClickObject = null;
        ClickableObject.OnClickObject += OnObjectClick;
    }

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        MaskPanel?.onClick.AddListener(OnClosePage);
        BTNClose?.onClick.AddListener(OnClosePage);
        BTNNext?.onClick.AddListener(OnNextPage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnObjectClick(ClickData data){
        if(canvasGroup.blocksRaycasts == true)
            return;

        currentData = data;
        currentPage = 0;
        Content.sprite = data.pageInfo[0];
        OpenSelf();

        foreach (Tweener item in ClickableObject.sparkTweener)
        {
            item.Pause();
        }
    }

    void OnClosePage(){
        foreach (Tweener item in ClickableObject.sparkTweener)
        {
            item.Play();
        }
        CloseSelf();
    }

    void OnNextPage(){
        if(currentData.pageInfo.Count > 1 && currentPage < currentData.pageInfo.Count - 1){
            currentPage++;
            Content.sprite = currentData.pageInfo[currentPage];
        }
    }
}
