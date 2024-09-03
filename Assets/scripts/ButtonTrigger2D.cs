using UnityEngine;

public class ButtonTrigger2D : MonoBehaviour
{
    public GameObject wall; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            Debug.Log("Wall disappears");
            wall.SetActive(false); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            Debug.Log("Wall reappears");
            wall.SetActive(true); 
        }
    }
}
