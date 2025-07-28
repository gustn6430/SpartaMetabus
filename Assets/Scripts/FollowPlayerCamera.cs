using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform target;

    public float minX = -4.8f; // ���� �� ��
    public float maxX = 4.8f;  // ������ �� ��
    public float minY = -2.6f; // �Ʒ� �� ��
    public float maxY = 2.6f;  // �� �� ��

    void LateUpdate()
    {
        if (target == null)
            return;

        // �÷��̾� ���󰡱�
        Vector3 newPos = transform.position;
        newPos.x = target.position.x;
        newPos.y = target.position.y;

        // ī�޶� ��ġ ����
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        // Z�� ī�޶� �Ÿ� ����
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
