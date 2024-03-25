using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // ��ҵ�Transform���
    private Vector3 offset; // ������������ҵĳ�ʼƫ����

    // ����Ϸ��ʼʱ����
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        // ���㲢�洢��ʼƫ����
        offset = transform.position - playerTransform.position;
    }

    // ÿ֡�����������λ��
    void Update()
    {
        // ��������������֮��ĳ�ʼƫ����
        transform.position = playerTransform.position + offset;
    }
}
