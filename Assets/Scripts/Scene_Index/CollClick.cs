using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollClick : MonoBehaviour
{
    public string sceneName;
    private void OnMouseDown()
    {
        SceneLoaderWithTransition.Instance.Fade(sceneName);
    }
}
