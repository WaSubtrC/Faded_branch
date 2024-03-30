using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCnavMesh : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;




    private void Start()
    {
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;
        
    }

    private void Update()
    {
    
        if (Input.GetMouseButtonDown(0)) 
        {
            navMeshAgent.SetDestination(MouseFollow());
            //navMeshAgent.SetDestination(new Vector3(13,0.2f,14));
        }
        
    }
    /// <summary>
    /// ��ȡ���������
    /// </summary>
    public Vector3 MouseFollow()
    {
        Vector3 screenPosition;//���������������ת��Ϊ��Ļ����
        Vector3 mousePositionOnScreen;//��ȡ�������Ļ����Ļ����
        Vector3 mousePositionInWorld;//�������Ļ����Ļ����ת��Ϊ��������
        //��ȡ���������У������У���λ�ã�ת��Ϊ��Ļ���ꣻ
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //��ȡ����ڳ���������
        mousePositionOnScreen = Input.mousePosition;
        //�ó����е�Z=��������Z
        mousePositionOnScreen.z = screenPosition.z;
        //������е�����ת��Ϊ��������
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //�����������ƶ�
        //transform.position = mousePositionInWorld;
        //����������X���ƶ�
        return new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, mousePositionInWorld.z);
    }

}
