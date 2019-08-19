using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    SpriteAnimation sprite_animation;
    Vector2 temp;
    float randompos;
    float t = 0;

	private void Awake()
	{
        sprite_animation = GetComponent<SpriteAnimation>();
	}

	private void FixedUpdate()
	{
        t += 0.02f;
        transform.position += new Vector3(0, Mathf.Sin(t) * 0.08f);
        sprite_animation.ImageUpdate(sprite_animation.image_speed);
	}
}
