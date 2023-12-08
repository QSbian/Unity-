using UnityEngine;
using System.Collections;
//���һֱ�������ǵĺ�
public class CameraFlow : MonoBehaviour
{
    public Transform target;
    public float distanceUp = 15f;
    public float distanceAway = 10f;
    public float smooth = 2f;//λ��ƽ���ƶ�ֵ
    public float camDepthSmooth = 5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �������������Զ��
        if ((Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView >= 3) || Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView <= 80)
        {
            Camera.main.fieldOfView += Input.mouseScrollDelta.y * camDepthSmooth * Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        //�����λ��
        Vector3 disPos = target.position + Vector3.up * distanceUp - target.forward * distanceAway; transform.position = Vector3.Lerp(transform.position, disPos, Time.deltaTime * smooth);
        //����ĽǶ�
        transform.LookAt(target.position);
    }
}
