using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    // 비활성화된 BestScoreText를 연결
    [SerializeField]
    private Text bestScoreText;

    void Start()
    {
        // 최고 점수를 직접 가져와 UI를 업데이트
        if (GameManager.Instance != null && bestScoreText != null)
        {
            bestScoreText.text = GameManager.Instance.BestScore.ToString();
        }
    }
}