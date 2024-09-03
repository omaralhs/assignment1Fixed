using UnityEngine;

public class PlatformColorChecker : MonoBehaviour
{
    public GameObject player; 
    private SpriteRenderer platformRenderer;
    private Collider2D platformCollider;
    private Collider2D playerCollider;
    private SpriteRenderer playerRenderer;

    private void Start()
    {
        platformRenderer = GetComponent<SpriteRenderer>();
        platformCollider = GetComponent<BoxCollider2D>();

        if (player != null)
        {
            playerCollider = player.GetComponent<Collider2D>();
            playerRenderer = player.GetComponent<SpriteRenderer>();
        }
        else
        {
            Debug.LogWarning("Player GameObject not assigned.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == playerCollider)
        {
            CheckColorMatch();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider == playerCollider)
        {
            CheckColorMatch();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider == playerCollider)
        {
           Invoke("RestoreCollision",2); 

        }
    }

    private void CheckColorMatch()
    {
        if (playerCollider == null || platformRenderer == null || platformCollider == null || playerRenderer == null)
        {
            Debug.LogWarning("Required components missing.");
            return;
        }

        bool colorMatches = playerRenderer.color == platformRenderer.color;

        if (!colorMatches)
        {
            Debug.Log("Colors do not match. Disabling platform collider.");
            platformCollider.enabled = false;
        }
        else
        {
            Debug.Log("Colors match. Platform collider enabled.");
            platformCollider.enabled = true;
        }
    }
    private void RestoreCollision()
    {
        if (platformCollider != null)
        {
            Debug.Log("Restoring platform collider.");
            platformCollider.enabled = true;
        }
        else
        {
            Debug.LogWarning("Platform collider not found.");
        }
    }

}
