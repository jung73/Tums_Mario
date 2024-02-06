using UnityEngine;
using UnityEngine.AI;

public class goomba : MonoBehaviour
{
    public float movementSpeed = 5f; // ������ �̵� �ӵ�
    public float rotationSpeed = 15f; // ������ ȸ�� �ӵ�
    public float detectionRadius = 30f; // �������� ������ �ݰ�, ���� ���� �ʿ�


    private Rigidbody rb;
    public GameObject player; // ������ ��ü

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
        // "Mario" �±׷� ������ ������Ʈ ã��, hierachy���� �������� �±� ����

    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= detectionRadius)
            {
                MoveTowardsMario(); // �������� ���� �̵�
                RotateTowardsPlayer(); // �÷��̾ ���� ȸ��
            }
        }
    }

    void MoveTowardsMario()
    {
        // �������� ���� ���ٸ� �̵���Ű�� ���� ���
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 movement = direction * movementSpeed * Time.deltaTime;

        // ���� �̵�
        animator.Play("Run");
        rb.MovePosition(transform.position + movement);
    }

    void RotateTowardsPlayer()
    {
        // �÷��̾ ���ϴ� ���� ���� ���
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // ���ٰ� �÷��̾ ���ϵ��� ȸ��
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        animator.Play("Damaged");
        Destroy(gameObject);
    }

    // �÷��̾�� �浹���� �� ȣ��Ǵ� �Լ�
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���� �������� ���� ���� �ְ�, �Ʒ� �������� �����´ٸ�
            if (collision.contacts[0].normal.y > 0.5f)
            {
                Destroy(gameObject); // ���� ����
            }
            else
            {
                animator.Play("Attack");
                //GameController.Instance.PlayerDamaged();
                //�������� ���ٰ� �浹���� ��
            }
        }
    }
}
