/*�浹 ��� 
 *
public GameObject player; �����ϰ� 

 private void OnTriggerEnter(Collider collider) //����: Ʈ����, ontriggerüũ 
//�ı����� �ʴ� ���� OnCollisionEnter(Collision collision)
    {
        if (collider.gameObject.tag == "Mario")
        {
            Debug.Log("�ε�");

            Destroy(gameObject); //�ı��ҰŸ� �־��
             

            if (player != null)
            {
                //���۳���
            }
            else
            {
                // �� �÷��̾�(����� ������)�� ã�Ƽ� ����. 
                GameObject newPlayer = GameObject.FindGameObjectWithTag("Mario");
                if (newPlayer != null)
                {
                    //���۳���
                }
                else
                {
                    Debug.LogWarning("�÷��̾ null");
                }
            }
        }
    }
 
 
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public GameObject player;
    public Player player1;

    // Start is called before the first frame update
    void Start()
    {
        player1 = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            Debug.Log("�ε�");



            player1.Hit(); //����
            
            
        }
    }
}
