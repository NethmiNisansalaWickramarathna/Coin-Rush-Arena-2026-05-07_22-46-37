using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    [Header("Health Settings")]
    public int maxLives = 3;
    private int currentLives;
    public bool isDead = false;
    public Slider healthSlider;

    private Vector2 movement;

    void Start()
    {
        
        currentLives = maxLives;

      
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxLives;
            healthSlider.value = maxLives;
        }
    }

    void Update()
    {
        if (isDead) return;

        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (isDead) return;

       
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    
    public void TakeDamage()
    {
        if (isDead) return;

        currentLives -= 1;
        if (healthSlider != null) healthSlider.value = currentLives;

      
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("ResetColor", 0.1f);

        if (currentLives <= 0) Die();
    }

    void ResetColor()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Die()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero; 
        Debug.Log("Player Marila!");
    }
}