using UnityEngine;

public class UIImageFloat : MonoBehaviour
{
    [Header("向上浮动距离")]
    public float floatDistance = 30f;
    [Header("浮动速度")]
    public float floatSpeed = 1.2f;

    private RectTransform rect;
    private Vector2 originAnchoredPos;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        // 记录UI原始锚点位置（最低位置）
        originAnchoredPos = rect.anchoredPosition;
    }

    void Update()
    {
        // 正弦 0~1 循环，只往上，不往下低于原位
        float t = (Mathf.Sin(Time.time * floatSpeed) + 1f) * 0.5f;
        float upOffset = Mathf.Lerp(0, floatDistance, t);

        // 只改Y，UI专用 anchoredPosition
        rect.anchoredPosition = new Vector2(originAnchoredPos.x, originAnchoredPos.y + upOffset);
    }
}