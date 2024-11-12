using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Keybinding")]
    [SerializeField] private List<KeyCode> keys = new List<KeyCode>();
    [SerializeField] private KeyCode moveLeft;
    [SerializeField] private KeyCode moveRight;
    [SerializeField] private KeyCode moveUp;

    [Header("Movement")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float maxSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isGrounded = true;

    [Header("Debugging")]
    [SerializeField] private bool isDebugging = false;
    /*
    [Header("Fall Through Platform")]
    [SerializeField] private GameObject platform;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float fallThroughTime;
    [SerializeField] private float velocityThreshold = 0.2f;
    [SerializeField] private float gracePeriod = 1f;
    [SerializeField] private bool isFalling = false;
    */

    // Start is called before the first frame update
    void Start()
    {
        ChangeKeybinds();
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Movement
        if (Input.GetKey(moveLeft))
        {
            rb.velocity += -Vector2.right * moveSpeed;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
        if (Input.GetKey(moveRight))
        {
            rb.velocity += Vector2.right * moveSpeed;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
        if (Input.GetKeyDown(moveUp) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true; // We can jump again
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false; // Don't allow double jumps
    }

    public void ChangeKeybinds()
    {
        // Reset all keybinds
        moveLeft = KeyCode.A;
        moveRight = KeyCode.D;
        moveUp = KeyCode.S;

        if (!isDebugging)
        {
            // Set Left keybind
            KeyCode keyBind = keys[Random.Range(0, keys.Count)];
            moveLeft = keyBind;

            // Set right keybind
            keyBind = keys[Random.Range(0, keys.Count)];
            while (keyBind == moveLeft)
            {
                keyBind = keys[Random.Range(0, keys.Count)];
            }
            moveRight = keyBind;

            // Set up keybind
            keyBind = keys[Random.Range(0, keys.Count)];
            while (keyBind == moveRight || keyBind == moveLeft)
            {
                keyBind = keys[Random.Range(0, keys.Count)];
            }
            moveUp = keyBind;
        }
        else
        {
            return;
        }
        

        /*
        Debug.Log($"Left: {moveLeft}");
        Debug.Log($"Right: {moveRight}");
        Debug.Log($"Up: {moveUp}");
        */
    }
}
