using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bell : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision) //���� ������... 
    {
        if (collision.gameObject.tag == "Mario") //�������� �ε�����
        {
            Debug.Log("�� �ε�");

            Destroy(gameObject);

            //catMario�� ü����, ����ī�޶��� target�ٲ��� 
            SwitchPlayer switchPlayer = GetComponent<SwitchPlayer>();
            if (switchPlayer != null)
            {
                // ����� �������� ��ȯ
                switchPlayer.SwitchToCat();
            }

        }
    }
}
