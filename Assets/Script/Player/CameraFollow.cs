using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // 玩家的Transform组件
    private Vector3 offset; // 摄像机相对于玩家的初始偏移量

    // 在游戏开始时调用
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        // 计算并存储初始偏移量
        offset = transform.position - playerTransform.position;
    }

    // 每帧更新摄像机的位置
    void Update()
    {
        // 保持摄像机与玩家之间的初始偏移量
        transform.position = playerTransform.position + offset;
    }
}
