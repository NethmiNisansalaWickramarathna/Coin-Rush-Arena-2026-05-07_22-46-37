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
        // ආරම්භයේදී ජීවිත ප්‍රමාණය සෙට් කිරීම
        currentLives = maxLives;

        // Rigidbody එක ස්ක්‍රිප්ට් එකෙන්ම හොයාගන්න උත්සාහ කිරීම (Inspector එකේ අමතක වුණොත්)
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

        // කීබෝඩ් එකෙන් Input ලබා ගැනීම (WASD හෝ Arrow Keys)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (isDead) return;

        // ප්ලේයර්ව මූව් කරවන ප්‍රධාන කොටස
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    // --- හතුරෙක්ගේ හැපුණොත් හානි සිදුවීම ---
    public void TakeDamage()
    {
        if (isDead) return;

        currentLives -= 1;
        if (healthSlider != null) healthSlider.value = currentLives;

        // හානි වූ විට රතු පැහැයෙන් දිස්වීම (Flash Effect)
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
        rb.linearVelocity = Vector2.zero; // මරුණු පසු චලනය නැවැත්වීම
        Debug.Log("Player Marila!");
    }
}