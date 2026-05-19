using UnityEngine;

public class UIFloat : MonoBehaviour
{
    [Header("浮动幅度")]
    public Vector2 floatAmplitude = new Vector2(15f, 8f);

    [Header("浮动速度")]
    public Vector2 floatSpeed = new Vector2(0.6f, 0.9f);

    [Header("随机相位偏移")]
    public bool useRandomOffset = true;

    private RectTransform rectTransform;
    private Vector2 startPosition;
    private Vector2 phaseOffset;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;

        if (useRandomOffset)
        {
            phaseOffset = new Vector2(Random.Range(0f, Mathf.PI * 2f), Random.Range(0f, Mathf.PI * 2f));
        }
    }

    void Update()
    {
        if (rectTransform == null) return;

        float xOffset = Mathf.Sin(Time.time * floatSpeed.x + phaseOffset.x) * floatAmplitude.x;
        float yOffset = Mathf.Cos(Time.time * floatSpeed.y + phaseOffset.y) * floatAmplitude.y;

        rectTransform.anchoredPosition = startPosition + new Vector2(xOffset, yOffset);
    }
}