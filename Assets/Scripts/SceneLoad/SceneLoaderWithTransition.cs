using System;
using System.Collections;
using TransitionsPlus;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ManualTransition : Singleton<ManualTransition>
{
    public TransitionAnimator animator;
    public string scene1;
    public string scene2;
    

    [ContextMenu("淡入淡出1")]
    public void StartFade1()
    {
        Fade(scene1);
    }
    [ContextMenu("淡入淡出2")]
    public void StartFade2()
    {
        Fade(scene2);
    }

    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }

    public void Fade(string sceneName)
    {
        animator.gameObject.SetActive(true);
        animator.enabled = true;
        animator.sceneNameToLoad = sceneName;
        animator.onTransitionEnd.AddListener(FadeEnd);
        animator.progress = 0;
        animator.Play();
        
    }

    private void FadeEnd()
    {
        animator.progress = 0;
        animator.gameObject.SetActive(false);
    }
}