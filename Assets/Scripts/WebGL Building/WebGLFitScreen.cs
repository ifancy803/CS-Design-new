using UnityEngine;

public class WebGLFitScreen : MonoBehaviour
{
    void Start()
    {
        Screen.fullScreen = false;
    }

    /*
    void Update()
    {
        // WebGL 不建议在 Update 里频繁 SetResolution
        // 自适应交给 html/css 处理即可
    }
    */
}