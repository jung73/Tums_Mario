using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public string targetTag = "Mario";
    private GameObject targetObject;
    public Transform target;
    public Vector3 offset;
    public bool isSwitch = false;
    public Vector3 initialPosition;
    public float yOffset = 2.0f;

    // ���� �� �ܾƿ��� ���� ����
    public float zoomSpeed = 2.0f;
    public float minZoomDistance = 2.0f;
    public float maxZoomDistance = 10.0f;

    private float currentZoomDistance;

    // Start is called before the first frame update
    void Start()
    {
        FindAndTarget(); //������ �� Ÿ�� �ѹ� ã��
        transform.position = initialPosition;
        currentZoomDistance = offset.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 �� �Է� ����
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelInput != 0)
        {
            // ���� �� �ܾƿ�
            currentZoomDistance -= scrollWheelInput * zoomSpeed;
            currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);
        }

        if (isSwitch) //����ġ�Ǿ�����
        {
            FindAndTarget(); //Ÿ�� �ѹ� ã��
            Debug.Log("Ÿ����ã��");
            isSwitch = false; //isswitch������ 
        }
        else if (target != null && target.transform != null)
        {
            Vector3 desiredPosition = target.position - transform.forward * currentZoomDistance + new Vector3(0, yOffset, 0);

            transform.position = desiredPosition;
        }
    }

    public void FindAndTarget() //Ÿ��ã��
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
    }
}
