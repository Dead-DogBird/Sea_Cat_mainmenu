using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingOjing : MonoBehaviour
{
    SpriteAnimation sprite_animation;

    private void Awake()
    {
        sprite_animation = GetComponent<SpriteAnimation>();
    }

    private void FixedUpdate()
    {
        sprite_animation.ImageUpdate(sprite_animation.image_speed);
    }
}
