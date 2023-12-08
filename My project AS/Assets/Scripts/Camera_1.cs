using UnityEngine;
using System.Collections;

public class Camera_1 : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        Rotate();
        Scale();
    }
    //����
    private void Scale()
    {
        float dis = offset.magnitude;
        dis += Input.GetAxis("Mouse ScrollWheel") * 5;

        if (dis < 10 || dis > 40)
        {
            return;
        }
        offset = offset.normalized * dis;
    }
    //���������ƶ�
    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 pos = transform.position;
            Vector3 rot = transform.eulerAngles;

            //Χ��ԭ����ת��Ҳ���Խ�Vector3.zero��Ϊ target.position,����Χ�ƹ۲������ת
            transform.RotateAround(Vector3.zero, Vector3.up, Input.GetAxis("Mouse X") * 10);
            transform.RotateAround(Vector3.zero, Vector3.left, Input.GetAxis("Mouse Y") * 10);
            float x = transform.eulerAngles.x;
            float y = transform.eulerAngles.y;
            //�����ƶ���Χ
            if (x < 20 || x > 45 || y < 0 || y > 40)
            {
                transform.position = pos;
                transform.eulerAngles = rot;
            }
            //  ������Բ�ֵ
            offset = transform.position - target.position;
        }
    }
}

