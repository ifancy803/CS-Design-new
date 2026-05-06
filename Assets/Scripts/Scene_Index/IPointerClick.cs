using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IPointerClick : MonoBehaviour,IPointerClickHandler
{
    public string sceneName;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneLoaderWithTransition.Instance.Fade(sceneName);
    }
}
