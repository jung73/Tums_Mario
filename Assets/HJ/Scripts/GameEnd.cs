using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Button triggerButton; // ��Ÿ�� ��ư
    public GameObject objectToTrigger; // Ʈ������ ������Ʈ
    public AudioSource audioEnd;
    public START audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴ��� Ȯ��
        {
            triggerButton.gameObject.SetActive(true); // ��ư Ȱ��ȭ
            PauseGame(); // ���� ����
            
            audioEnd.Play();

        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // ���� �ӵ��� 0���� �����Ͽ� ����
        audio.adioMain.Stop();
    }
}
