using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class START : MonoBehaviour
{
    public Button startButton; // ���� ���� ��ư
    public Button triggerButton; // ��
    public GameObject objectToTrigger; // Ʈ������ ������Ʈ

    private void Start()
    {
        // ���� ��ư Ŭ�� �� ���� ���� �Լ� ȣ��
        startButton.onClick.AddListener(StartGame);

        // ���� ���� �� ����
        PauseGame();
    }

    void StartGame()
    {
        ResumeGame(); // ���� ���� �� ���� ���� ����
        startButton.gameObject.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // ���� �ӵ��� 0���� �����Ͽ� ����
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // ���� �ӵ��� 1�� �����Ͽ� �簳
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mario")) // �÷��̾�� �浹�ߴ��� Ȯ��
        {
            triggerButton.gameObject.SetActive(true); // ��ư Ȱ��ȭ
            PauseGame(); // ���� ����
        }
    }
}