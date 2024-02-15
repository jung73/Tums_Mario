using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15;
    public float jumpForce = 15;
    float hAxis;
    float vAxis;
    bool wDown;
    bool jDown;
    bool isJump;
    public Transform tf;

    Vector3 moveVec;

    Animator anim;
    Rigidbody rigid;

    public int health = 3;

    public static int coin = 0;

    public AudioSource jumpadio;
    

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        ClimbWall();
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
        if (moveVec != Vector3.zero) // moveVec이 0이 아닐 때만 회전
        {
            transform.LookAt(transform.position + moveVec);
        }
    }

    //점프
    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
            jumpadio.Play();
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
    public void Die()
    {
        if (health == 0)
        {
            Debug.Log("Player is dead.");
        }
    }

    //맞음 
    public void Hit()
    {
        health--;
        Debug.Log($"health: {health}");
        if (health <= 0)
        {
            Die();
        }
        tf.localScale = new Vector3(1.2f, 1f, 1.2f);
    }

    void ClimbWall()
    {
        // 플레이어가 특정 방향으로 이동하고 있는지 확인
        if (moveVec.magnitude > 0)
        {
            // 플레이어 바로 앞 방향으로 레이캐스트 발사
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
            {
                // 레이캐스트에 벽이 맞으면 해당 벽을 오를 수 있게 함
                if (hit.collider.CompareTag("Wall"))
                {
                    float distanceToWall = hit.distance;

                    // 일정한 반경 안에 들어왔을 때만 높은 점프 트리거 호출
                    if (distanceToWall < 10f)
                    {
                        // 높은 점프 트리거 호출
                        jumpForce = 30f;
                    }
                    else jumpForce = 15f;
                }
            }
            else jumpForce = 15f;
            /*else
            {
                // 레이캐스트가 벽에 닿지 않은 상태에서도 일정한 반경 안에 들어왔을 때만 높은 점프 트리거 호출
                if (Vector3.Distance(transform.position, hit.point) < 10f)
                {
                    // 높은 점프 트리거 호출
                    jumpForce = 25f;
                }
                else jumpForce = 30f;
            }*/
        }
    }
    

}
