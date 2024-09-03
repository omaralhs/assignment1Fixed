using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    public Color[] colors = new Color[4]; 
    private SpriteRenderer playerRenderer;
    private int currentColorIndex = 0;

    private void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();

        colors[0] = Color.red; 
        colors[1] = Color.blue;
        colors[2] = Color.green;  
        colors[3] = Color.yellow; 

        playerRenderer.color = colors[currentColorIndex];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        playerRenderer.color = colors[currentColorIndex];
    }
}
