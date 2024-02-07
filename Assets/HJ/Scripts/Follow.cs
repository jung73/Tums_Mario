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
    // Start is called before the first frame update
    void Start()
    {
        FindAndTarget(); //������ �� Ÿ�� �ѹ� ã��
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (isSwitch) //����ġ�Ǿ�����
        {
            FindAndTarget(); //Ÿ�� �ѹ� ã��
            Debug.Log("Ÿ����ã��");
            isSwitch = false; //isswitch������ 
        }
        else if (target != null && target.transform != null)
        {
            transform.position = new Vector3(target.position.x + offset.x, transform.position.y, target.position.z + offset.z);
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
