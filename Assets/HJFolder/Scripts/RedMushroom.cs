using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroom : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
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

            Destroy(gameObject);

            if (player != null)
            {
                player.transform.localScale = new Vector3(2f, 2f, 2f);
            }
            else
            {
                // �� �÷��̾�(����� ������)�� ã�Ƽ� ũ�⸦ ����
                GameObject newPlayer = GameObject.FindGameObjectWithTag("Mario");
                if (newPlayer != null)
                {
                    newPlayer.transform.localScale = new Vector3(2f, 2f, 2f);
                }
                else
                {
                    Debug.LogWarning("�÷��̾ null");
                }
            }
        }

    
    }
}
