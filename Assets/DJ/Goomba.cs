using UnityEngine;
using UnityEngine.AI;

public class goomba : MonoBehaviour
{
    public float movementSpeed = 5f; // 굼바의 이동 속도
    public float rotationSpeed = 15f; // 굼바의 회전 속도
    public float detectionRadius = 30f; // 마리오를 감지할 반경, 추후 변경 필요


    private Rigidbody rb;
    public GameObject player; // 마리오 객체

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        animator.Play("Wait");
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        // "Mario" 태그로 설정된 오브젝트 찾기, hierachy에서 마리오에 태그 설정

    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= detectionRadius)
            {
                MoveTowardsMario(); // 마리오를 향해 이동
                RotateTowardsPlayer(); // 플레이어를 향해 회전
            }
        }
    }

    void MoveTowardsMario()
    {
        // 마리오를 향해 굼바를 이동시키는 방향 계산
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 movement = direction * movementSpeed * Time.deltaTime;

        // 굼바 이동
        animator.Play("Run");
        rb.MovePosition(transform.position + movement);
    }

    void RotateTowardsPlayer()
    {
        // 플레이어를 향하는 방향 벡터 계산
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // 굼바가 플레이어를 향하도록 회전
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        animator.Play("Damaged");
        Destroy(gameObject);
    }

    // 플레이어와 충돌했을 때 호출되는 함수
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 만약 마리오가 굼바 위에 있고, 아래 방향으로 내려온다면
            if (collision.contacts[0].normal.y > 0.5f)
            {
                Destroy(gameObject); // 굼바 삭제
            }
            else
            {
                animator.Play("Attack");
                //GameController.Instance.PlayerDamaged();
                //마리오와 굼바가 충돌했을 때
            }
        }
    }
}
