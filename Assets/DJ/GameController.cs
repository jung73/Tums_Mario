using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance; // �̱��� ������ ����Ͽ� �ν��Ͻ� ����

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ���ٿ��� ������ ������ �� �������� damage�� �޴� �κ�
    public void PlayerDamaged()
    {
        //�������� �Դ� ���� �߰�
    }

    // �������� ������ �� ������ ��
    public void GameOver()
    {
        // ���� ���� ���� �߰�

    }
}
