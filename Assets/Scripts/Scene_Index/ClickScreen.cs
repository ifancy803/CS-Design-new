using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScreen : MonoBehaviour
{
    public string sceneName;
    void Update()
    {
        // 检测鼠标左键点击（PC）或触摸屏点击（移动端）
        if (Input.GetMouseButtonDown(0))
        {
            SceneLoaderWithTransition.Instance.Fade(sceneName);
        }
    }
}
