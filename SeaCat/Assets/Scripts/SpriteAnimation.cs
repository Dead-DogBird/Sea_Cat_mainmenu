using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public float image_index;
    public float image_speed = 0.2f;

    int length = 0;
    SpriteRenderer spriteRenderer;

	private void Awake()
	{
        length = sprites.Length;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}


	public void ImageUpdate(float speed)
	{
        image_index += speed;
        if (image_index > length)
        {
            image_index = 0;
        }

        spriteRenderer.sprite = sprites[(int)image_index];
	}
}
