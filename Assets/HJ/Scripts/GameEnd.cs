using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Button triggerButton; // ��Ÿ�� ��ư
    public GameObject objectToTrigger; // Ʈ������ ������Ʈ

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴ��� Ȯ��
        {
            triggerButton.gameObject.SetActive(true); // ��ư Ȱ��ȭ
            PauseGame(); // ���� ����
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // ���� �ӵ��� 0���� �����Ͽ� ����
    }
}
