using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RigidbodyType2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveInput;
    public Animator animator;
    public float movementSpeed;
    private Rigidbody2D rb;

    [SerializeField] private float moveX;
    [SerializeField] private float moveY;
    [SerializeField] private bool _isMoving;
    public bool isMoving 
    { 
        get { return _isMoving; } 
        private set
        {
            _isMoving = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        transform.position = new Vector2(0,0);
    }
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.deltaTime * movementSpeed * Input.GetAxis("Horizontal"));
        transform.Translate(Vector2.up * Time.deltaTime * movementSpeed * Input.GetAxis("Vertical"));
    }

    public void onMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        isMoving = _moveInput != Vector2.zero;

        setDirection(_moveInput);
        animator.SetBool("isMoving", isMoving);
    }

    private void setDirection(Vector2 _moveInput)
    {
        moveX = _moveInput.x;
        moveY = _moveInput.y;
        
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }
}