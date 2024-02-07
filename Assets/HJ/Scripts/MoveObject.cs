using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 targetPosition;
    private bool startMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position + (Vector3.forward * -1.5f); // ��ǥ ��ġ ����
        startMoving = true;
    }

    void FixedUpdate()
    {
        if (startMoving)
        {
            // ���� ��ġ���� ��ǥ ��ġ���� ���� ���� ���
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            // ��ǥ ��ġ�� �������� �ʾ�����, Rigidbody�� MovePosition�� ����Ͽ� �̵�
            if ((targetPosition - transform.position).magnitude > 0.1f) // ��ǥ���� �Ÿ��� ����� ������� ������
            {
                rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
            }
            else
            {
                startMoving = false; // ��ǥ�� �����ϸ� �̵� ����
                Debug.Log("�̵� �ߴ�");
            }
        }
    }
}