using UnityEngine;

public class OrbitLookAround : MonoBehaviour
{
    [Header("环绕目标")]
    public Transform target;

    [Header("旋转速度")]
    public float rotateSpeed = 3f;
    [Header("滚轮缩放速度")]
    public float zoomSpeed = 5f;
    [Header("最近/最远距离")]
    public float minDistance = 1f;
    public float maxDistance = 20f;

    private float _distance;
    private float _xAngle;
    private float _yAngle;

    void Start()
    {
        // 初始化相机与目标距离、角度
        _distance = Vector3.Distance(transform.position, target.position);
        _xAngle = transform.eulerAngles.x;
        _yAngle = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 滚轮缩放
        _distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        _distance = Mathf.Clamp(_distance, minDistance, maxDistance);

        // 右键按住拖动旋转
        if (Input.GetMouseButton(1))
        {
            _yAngle += Input.GetAxis("Mouse X") * rotateSpeed;
            _xAngle -= Input.GetAxis("Mouse Y") * rotateSpeed;
            // 限制上下视角，防止翻过去
            _xAngle = Mathf.Clamp(_xAngle, -20f, 80f);
        }

        // 计算相机位置
        Quaternion rot = Quaternion.Euler(_xAngle, _yAngle, 0);
        Vector3 pos = rot * new Vector3(0, 0, -_distance) + target.position;

        transform.rotation = rot;
        transform.position = pos;
    }
}