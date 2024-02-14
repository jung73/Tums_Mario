using UnityEngine;

public class Pipe2 : MonoBehaviour
{
    public Transform destinationCube; // �̵��� ������ ť���� Transform
    public float offsetDistance = 1f;
    public float ZDistance = 0f;
    public float YDistance = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mario")) // �÷��̾�� �浹�ߴ��� Ȯ��
        {
            Vector3 offset = new Vector3(offsetDistance, ZDistance, YDistance); // x������ offsetDistance ��ŭ �̵��� ���� ����
            other.transform.position = destinationCube.position + offset; // �÷��̾� ��ġ�� ������ ť���� ��ġ�� ����
        }
    }
}
