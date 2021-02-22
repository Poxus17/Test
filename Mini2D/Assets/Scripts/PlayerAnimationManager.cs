using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationManager : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        PlatformerPlayerController2D.OnChangeDirection += UpdateAnimation;
        Jumping.OnJump += UpdateAnimation;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateAnimation(Vector2 dir)
    {
        animator.SetInteger("Index", PublicData.animationDirectionToIndex[dir]);

        // Thaw if sprite is symmetrical
        /*if(dir.x != 0)
        {
            GetComponent<SpriteRenderer>().flipX = (dir.x < 0);
        }*/
    }
}
