using System;
using System.Collections;
using TransitionsPlus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualTransition : MonoBehaviour
{
    public TransitionAnimator animator;

    private void Awake()
    {
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {
        DontDestroyOnLoad(gameObject);
        
        // 1. 设置进度为 1（完全遮罩/淡出完成）
        animator.progress = 1f;
        animator.autoPlay = true;
        // 2. 等待一小段时间确保渲染
        yield return null;
        
        // 3. 加载场景
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("2");
        asyncLoad.allowSceneActivation = false;
        while (asyncLoad.progress < 0.9f) yield return null;
        asyncLoad.allowSceneActivation = true;
        yield return null;
        
        // 4. 设置进度为 0（淡入完成）
        animator.progress = 0f;
    }
}