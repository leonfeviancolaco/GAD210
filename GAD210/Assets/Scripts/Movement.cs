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
            rb.velocity = -transform.right * moveSpeed;
        }
        if (Input.GetKey(moveRight))
        {
            rb.velocity = transform.right * moveSpeed;
        }
        if (Input.GetKeyDown(moveUp) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
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

        Debug.Log($"Left: {moveLeft}");
        Debug.Log($"Left: {moveRight}");
        Debug.Log($"Left: {moveUp}");
    }
}
