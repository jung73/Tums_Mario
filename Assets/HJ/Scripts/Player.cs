using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15;
    float hAxis;
    float vAxis;
    bool wDown;
    bool jDown;
    bool isJump;

    Vector3 moveVec;

    Animator anim;
    Rigidbody rigid;

    public static int health = 3;

    public static int coin = 0;
    

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        Die();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }

    //움직임
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
        speed = 15;
        if (wDown == true)
        {
            speed = 7;
        }
        

        /*moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        //if (isJump)
            

        Vector3 newPos = transform.position + moveVec * speed * Time.deltaTime;

        rigid.MovePosition(newPos);

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
        speed = wDown ? 7 : 15;*/
    }

    void Turn() //회전
    {
        transform.LookAt(transform.position + moveVec);
    }

    //점프
    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    //충돌
    private void OnCollisionEnter(Collision collision)
    {
        //점프 여러번 못하게
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }

        //피깎이게
        if (collision.gameObject.tag == "Monster")
        {
            health -= 1;
        }
    }

    //사망 
    private void Die()
    {
        if (health == 0)
        {
            //사망
        }
    }

    //맞음 
    public static void Hit()
    {
        health--;
        Debug.Log($"health: {health}");
    }

}
