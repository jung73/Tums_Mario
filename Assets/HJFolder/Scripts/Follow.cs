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
    // Start is called before the first frame update
    void Start()
    {
        FindAndTarget(); //시작할 때 타겟 한번 찾음
    }

    // Update is called once per frame
    void Update()
    {

        if (isSwitch) //스위치되었으면
        {
            FindAndTarget(); //타겟 한번 찾고
            Debug.Log("타겟을찾다");
            isSwitch = false; //isswitch내리고 
        }
        else if (target != null && target.transform != null)
        {
            transform.position = target.position + offset;
        }
    }

    public void FindAndTarget() //타겟찾음
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
    }
}
