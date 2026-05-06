using System;
using System.Collections;
using TransitionsPlus;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoaderWithTransition : Singleton<SceneLoaderWithTransition>
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
        animator.autoPlay = true;
        animator.sceneNameToLoad = sceneName;
        animator.profile.invert = false;
        animator.onTransitionEnd.AddListener(FadeEnd);
        animator.progress = 0;
        animator.Play();
        
    }
    
    private void FadeEnd()
    {
        StartCoroutine(FadeEndDelay());
    }

    IEnumerator FadeEndDelay()
    {
        yield return new WaitForSeconds(0.5f);
        animator.onTransitionEnd.RemoveListener(FadeEnd);
        animator.profile.invert = true;
        animator.Play();
        animator.autoPlay = false;
    }
}