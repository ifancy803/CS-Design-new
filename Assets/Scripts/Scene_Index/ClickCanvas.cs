using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCanvas : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneLoaderWithTransition.Instance.Fade("Scene_Page_1.0");
        }
    }
}
