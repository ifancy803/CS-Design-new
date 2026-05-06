using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    [Header("公转中心点")]
    public Transform centerPoint;

    [Header("公转速度")]
    public float rotateSpeed = 20f;

    [Header("公转半径")]
    public float orbitRadius = 3f;

    void Start()
    {
        // 初始化：把物体放到中心点外侧指定半径位置
        if (centerPoint != null)
        {
            Vector3 dir = (transform.position - centerPoint.position).normalized;
            transform.position = centerPoint.position + dir * orbitRadius;
        }
    }

    void Update()
    {
        if (centerPoint == null) return;

        // 绕中心点 Y 轴水平旋转
        transform.RotateAround(centerPoint.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }
}