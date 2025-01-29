using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScrollBG : MonoBehaviour
{
    [SerializeField] private GameObject scrollObject;
    [SerializeField] private float scrollSpeed;
    [SerializeField]  private SpriteRenderer spriteRenderer;
    private void Start()
    {
        Texture2D yourTexture = Resources.Load<Texture2D>("Assers/Materials/Background/Layer_0003_6.png");
        // Check if SpriteRenderer is assigned in the Inspector
        if (spriteRenderer == null)
        {
            spriteRenderer = scrollObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = scrollObject.AddComponent<SpriteRenderer>();
            }
        }

        // Ensure material has a texture
        if (spriteRenderer.material.mainTexture == null)
        {
            // Assign a default texture (replace with your actual texture)
            spriteRenderer.material.mainTexture = yourTexture;  // Assign texture here
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
        Vector2 currentOffset = spriteRenderer.material.mainTextureOffset;
        float offset = scrollSpeed * (Time.deltaTime);
        spriteRenderer.material.mainTextureOffset = new Vector2(currentOffset.x+offset, 0);
        Debug.Log("offset is " + currentOffset);
    }
}
