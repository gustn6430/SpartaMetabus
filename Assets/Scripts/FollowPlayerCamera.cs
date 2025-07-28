using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform target;

    public float minX = -4.8f; // 왼쪽 맵 끝
    public float maxX = 4.8f;  // 오른쪽 맵 끝
    public float minY = -2.6f; // 아래 맵 끝
    public float maxY = 2.6f;  // 위 맵 끝

    void LateUpdate()
    {
        if (target == null)
            return;

        // 플레이어 따라가기
        Vector3 newPos = transform.position;
        newPos.x = target.position.x;
        newPos.y = target.position.y;

        // 카메라 위치 제한
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        // Z는 카메라 거리 유지
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
