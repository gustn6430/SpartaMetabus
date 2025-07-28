using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    GameManager gameManager;

    public Button StartButton;
    public RawImage RawImage;

    AudioSource audioSource;
    public AudioClip meet;
    void Start()
    {
        StartButton.gameObject.SetActive(false);
        RawImage.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = this.meet;
        gameManager = GameManager.Instance;
        StartButton.onClick.AddListener(OnStartButtonClicked);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("플레이어가 미니게임 영역에 들어옴.");
        StartButton.gameObject.SetActive(true);
        RawImage.gameObject.SetActive(true);
        audioSource.Play();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어가 미니게임 영역을 벗어남.");
            StartButton.gameObject.SetActive(false);
            RawImage.gameObject.SetActive(false);
        }
    }

    void OnStartButtonClicked()
    {
        Debug.Log("버튼 클릭됨");
        gameManager.StartFlappyPlaneGame();
    }
}
