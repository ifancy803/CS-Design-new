using UnityEngine;
using DG.Tweening;

public class BreathScale : MonoBehaviour
{
    [Header("缩放参数")]
    public Vector3 minScale = Vector3.one;
    public Vector3 maxScale = new Vector3(1.2f, 1.2f, 1.2f);
    public float duration = 1f;
    public Ease easeType = Ease.InOutSine;
    
    private Tweener scaleTweener;
    
    void Start()
    {
        StartBreathing();
    }
    
    void StartBreathing()
    {
        // 先缩放到最小
        transform.localScale = minScale;
        
        // 创建循环缩放动画（Yoyo模式）
        scaleTweener = transform.DOScale(maxScale, duration)
            .SetEase(easeType)
            .SetLoops(-1, LoopType.Yoyo);
    }
    
    public void StopBreathing()
    {
        if (scaleTweener != null)
        {
            scaleTweener.Kill();
            scaleTweener = null;
        }
    }
    
    void OnDestroy()
    {
        StopBreathing();
    }
}