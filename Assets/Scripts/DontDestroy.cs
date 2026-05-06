using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        // 这行代码让该物体在加载新场景时不被销毁
        DontDestroyOnLoad(gameObject);
    }
}