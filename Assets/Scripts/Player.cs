using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D _rigidbody;
    private Animator animator;
    private SpriteRenderer _spriterenderer;
    private Vector2 moveInput;

    public float MaxX = 12.5f;
    public float MinX = -12.5f;
    public float MaxY = 6.5f;
    public float MinY = -6.2f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        // 입력 처리 (WASD)
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A, D
        moveInput.y = Input.GetAxisRaw("Vertical");   // W, S

        // 대각선 이동 시 속도 보정
        moveInput = moveInput.normalized;

        // 애니메이션 상태 설정
        animator.SetBool("isMoving", moveInput != Vector2.zero);

        // 캐릭터 좌우 방향 회전 처리
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // 왼쪽
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // 오른쪽
        }
    }

    void FixedUpdate()
    {
        // 이동할 위치 계산
        Vector2 targetPos = _rigidbody.position + moveInput * moveSpeed * Time.fixedDeltaTime;

        // 위치 제한 (Clamp)
        targetPos.x = Mathf.Clamp(targetPos.x, MinX, MaxX);
        targetPos.y = Mathf.Clamp(targetPos.y, MinY, MaxY);

        // 이동 적용
        _rigidbody.MovePosition(targetPos);
    }
}
