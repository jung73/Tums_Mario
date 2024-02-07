using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; //ȸ���� ���� 

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * -1 * Time.deltaTime); //���ڸ�ȸ��
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Mario")
        {
            Debug.Log("�ε�");

            Destroy(gameObject);
             

            if (player != null)
            {
                //���ξ�1 �ø��� �ڵ� �ۼ��ؾߵ�
                Player.coin++;
                Debug.Log($"coin: {Player.coin}");
            }
            else
            {
                // �� �÷��̾�(����� ������)�� ã�Ƽ� ����. 
                GameObject newPlayer = GameObject.FindGameObjectWithTag("Mario");
                if (newPlayer != null)
                {
                    //���ξ�1 �ø��� �ڵ� �ۼ��ؾߵ�
                    Player.coin++;
                    Debug.Log($"coin: {Player.coin}");
                }
                else
                {
                    Debug.LogWarning("�÷��̾ null");
                }
            }
        }
    }
}
