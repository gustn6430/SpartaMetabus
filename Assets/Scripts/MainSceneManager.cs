using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    // ��Ȱ��ȭ�� BestScoreText�� ����
    [SerializeField]
    private Text bestScoreText;

    void Start()
    {
        // �ְ� ������ ���� ������ UI�� ������Ʈ
        if (GameManager.Instance != null && bestScoreText != null)
        {
            bestScoreText.text = GameManager.Instance.BestScore.ToString();
        }
    }
}