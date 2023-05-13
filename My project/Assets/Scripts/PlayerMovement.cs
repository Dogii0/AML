using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RigidbodyType2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveInput;
    public Animator animator;
    public Animation animation;
    private Rigidbody2D rb;
    public float movementSpeed;
    private KeyCode lastKeyPressed;

    [SerializeField] private int playerDirection;
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
        animation = GetComponent<Animation>();
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
        // transform.Translate(Vector2.right * (Time.deltaTime * movementSpeed * Input.GetAxis("Horizontal")));
        // transform.Translate(Vector2.up * Time.deltaTime * movementSpeed * Input.GetAxis("Vertical"));

        rb.velocity = new Vector2(
            _moveInput.x * movementSpeed,
            _moveInput.y * movementSpeed);
    }

    public void onMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        isMoving = _moveInput != Vector2.zero;

        setDirection(_moveInput);
        animator.SetBool(AnimationStrings.isMoving, isMoving);
    }

    private void setDirection(Vector2 _moveInput)
    {
        moveX = _moveInput.x;
        moveY = _moveInput.y;

        if (Input.GetButtonDown("Horizontal"))
        {
            if (moveX < 0) { playerDirection = 4; }  // left
            else { playerDirection = 2; }  // right
        }
        else if (Input.GetButtonDown("Vertical"))
        {
            if (moveY < 0) { playerDirection = 1; }  // down
            else { playerDirection = 3; }  // up
        }

        animator.SetFloat(AnimationStrings.moveX, moveX);
        animator.SetFloat(AnimationStrings.moveY, moveY);
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // animator.enabled = false;
            animator.SetTrigger(AnimationStrings.attackTrigger);
            animator.SetInteger(AnimationStrings.playerDirection, playerDirection);
        }
    }

}