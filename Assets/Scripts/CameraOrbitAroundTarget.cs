using UnityEngine;

public class CameraAutoOrbitKeepHeight : MonoBehaviour
{
    [Header("环绕目标点（锥顶）")]
    public Transform targetPoint;

    [Header("公转速度")]
    public float orbitSpeed = 1.2f;

    private float _angle;
    private float _fixedCamY;
    private Vector3 _originTargetPos;

    void Start()
    {
        // 记录相机初始高度，全程锁死
        _fixedCamY = transform.position.y;
        _originTargetPos = targetPoint.position;

        // 计算初始相对角度，保证从当前位置开始绕圈
        Vector3 dir = transform.position - targetPoint.position;
        dir.y = 0; // 只看水平方向
        _angle = Mathf.Atan2(dir.z, dir.x);
    }

    void LateUpdate()
    {
        if (targetPoint == null) return;

        // 累加旋转角度
        _angle += orbitSpeed * Time.deltaTime;

        // 水平圆周坐标
        float radius = Vector3.Distance(
            new Vector3(transform.position.x, 0, transform.position.z),
            new Vector3(targetPoint.position.x, 0, targetPoint.position.z)
        );

        float newX = targetPoint.position.x + Mathf.Cos(_angle) * radius;
        float newZ = targetPoint.position.z + Mathf.Sin(_angle) * radius;

        // 关键：Y 固定为相机最开始的高度，完全不变
        transform.position = new Vector3(newX, _fixedCamY, newZ);

        // 始终看向目标点，保持原有瞄准角度
        transform.LookAt(targetPoint);
    }
}