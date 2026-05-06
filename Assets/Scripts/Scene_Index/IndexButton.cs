using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexButton : MonoBehaviour
{
    public void GetIndexButtonDown()
    {
        SceneLoaderWithTransition.Instance.Fade("Scene_Page_1.0");
    }
}
