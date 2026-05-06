using UnityEngine;
using UnityEngine.UI;

public class UIFrameAnimation : MonoBehaviour
{
    public Image targetImage;
    public Sprite[] frames;
    public float fps = 15f;

    private int _index;
    private float _timer;

    void Reset()
    {
        targetImage = GetComponent<Image>();
    }

    void Update()
    {
        if (targetImage == null) return;
        if (frames == null || frames.Length == 0) return;

        _timer += Time.deltaTime;

        if (_timer >= 1f / fps)
        {
            _timer = 0f;
            _index = (_index + 1) % frames.Length;
            targetImage.sprite = frames[_index];
        }
    }
}