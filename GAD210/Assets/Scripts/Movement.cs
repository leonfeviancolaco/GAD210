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

    [Header("Fall Through Platform")]
    [SerializeField] private GameObject platform;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float fallThroughTime;
    [SerializeField] private float velocityThreshold = 0.2f;
    [SerializeField] private float gracePeriod = 1f;
    [SerializeField] private bool isFalling = false;

    // Start is called before the first frame update
    void Start()
    {
        ChangeKeybinds();
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(moveLeft))
        {
            rb.velocity += -Vector2.right * moveSpeed;
        }
        if (Input.GetKey(moveRight))
        {
            rb.velocity += Vector2.right * moveSpeed;
        }
        if (Input.GetKeyDown(moveUp) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Force);
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        if (isFalling)
        {
            platform.SetActive(false);
            timer += Time.deltaTime;
            if (timer >= fallThroughTime)
            {
                timer = 0f;
                platform.SetActive(true);
            }
        }
        else if (isGrounded)
        {
            if (rb.velocity.magnitude <= velocityThreshold)
            {
                timer += Time.deltaTime;
                if (timer >= gracePeriod)
                {
                    isFalling = true;
                    timer = 0f;
                }
            }
            else timer = 0f;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
            platform = collision.gameObject;
        }
        //maxSpeed = 10f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        //maxSpeed = 500f;
    }

    public void ChangeKeybinds()
    {
        // Reset all keybinds
        moveLeft = KeyCode.None;
        moveRight = KeyCode.None;
        moveUp = KeyCode.None;

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

        /*
        Debug.Log($"Left: {moveLeft}");
        Debug.Log($"Right: {moveRight}");
        Debug.Log($"Up: {moveUp}");
        */
    }
}
