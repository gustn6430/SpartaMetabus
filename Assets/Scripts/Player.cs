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
        // �Է� ó�� (WASD)
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A, D
        moveInput.y = Input.GetAxisRaw("Vertical");   // W, S

        // �밢�� �̵� �� �ӵ� ����
        moveInput = moveInput.normalized;

        // �ִϸ��̼� ���� ����
        animator.SetBool("isMoving", moveInput != Vector2.zero);

        // ĳ���� �¿� ���� ȸ�� ó��
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // ����
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // ������
        }
    }

    void FixedUpdate()
    {
        // �̵��� ��ġ ���
        Vector2 targetPos = _rigidbody.position + moveInput * moveSpeed * Time.fixedDeltaTime;

        // ��ġ ���� (Clamp)
        targetPos.x = Mathf.Clamp(targetPos.x, MinX, MaxX);
        targetPos.y = Mathf.Clamp(targetPos.y, MinY, MaxY);

        // �̵� ����
        _rigidbody.MovePosition(targetPos);
    }
}
