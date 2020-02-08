using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider))]
public class ClickableObject : MonoBehaviour
{
    public static List<Tweener> sparkTweener = new List<Tweener>();
    public static Action<ClickData> OnClickObject;
    public List<Sprite> PageInfo;
    
    float sparkDuration = 1.5f;
    SpriteGlow.SpriteGlowEffect spr;
    Color sparkColor = new Color32(255, 255, 255, 0);

    void Start()
    {
        //spr.DOColor(sparkColor, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        spr = GetComponent<SpriteGlow.SpriteGlowEffect>();
        if(spr != null){
            Tweener tw = DOTween.To(() => spr.GlowColor, x => spr.GlowColor = x, sparkColor, sparkDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            sparkTweener.Add(tw);
        }
    }

    private void OnMouseDown() {
        ClickData data = new ClickData(){
            pageInfo = this.PageInfo,
        };
        OnClickObject?.Invoke(data);
        //Debug.Log("Click");
    }

}

[Serializable]
public class ClickData {
    public List<Sprite> pageInfo;
}