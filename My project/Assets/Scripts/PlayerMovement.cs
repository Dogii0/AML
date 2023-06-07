using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RigidbodyType2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveInput;
    private Animator animator;
    private Rigidbody2D rb;
    private float movementSpeed;
    private KeyCode lastKeyPressed;
    private Inventory inventory;
    public static Item weapon;

    [SerializeField] private int playerDirection;
    [SerializeField] private float moveX;
    [SerializeField] private float moveY;
    [SerializeField] private bool _isMoving;
    [SerializeField] private bool _flipAnimation;

    [SerializeField] private int cry;
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
        cry = 0;
        movementSpeed = 1.5f;
        transform.position = new Vector2(0,0);
    }
    void Update()
    {
        inventory = new Inventory();
        
        switch (weapon.itemType)
        {
            case Item.ItemType.Tree:
                cry = 1;
                break;
            case Item.ItemType.FireExt:
                cry = 2;
                break;
            case Item.ItemType.Umbrella:
                cry = 3;
                break;
            default:
                cry = 0;
                break;
        }
        
        animator.SetInteger(AnimationStrings.weaponType, cry);
    }

    private void FixedUpdate()
    {
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
        animator.SetFloat(AnimationStrings.moveX, moveX);
        animator.SetFloat(AnimationStrings.moveY, moveY);
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
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetInteger(AnimationStrings.weaponType, inventory.getWeaponType());
            animator.SetBool(AnimationStrings.flipAnimation, _flipAnimation);
            animator.SetTrigger(AnimationStrings.attackTrigger);
            animator.SetInteger(AnimationStrings.playerDirection, playerDirection);
        }
    }

    public void gimmeWeaponPls(Item item)
    {
        weapon = item;
    }
}