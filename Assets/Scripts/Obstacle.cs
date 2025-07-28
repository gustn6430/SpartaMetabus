using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSiezMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObjcect;
    public Transform bottomObject;

    public float widthPadding = 4f;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstaclCount)
    {
        float holeSize = Random.Range(holeSiezMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObjcect.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placeposition = lastPosition + new Vector3(widthPadding, 0);
        placeposition.y = Random.Range(lowPosY, highPosY);

        transform.position = placeposition;

        return placeposition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Plane plane = collision.gameObject.GetComponent<Plane>();
        if (plane != null)
        {
            gameManager.AddScore(1);
        }
    }
}
