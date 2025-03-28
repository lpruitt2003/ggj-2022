using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**=====================================
Class CharacterAnimationController
-------------------------
Description:

Handle the animation of the player's character
--------------------------
Author(s):
Selin Kaya
=====================================*/
public class Character2AnimationController : MonoBehaviour
{
    private Animator characterAnimator;

    void Start()
    {
        characterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // If character is running, do the sprint animation
        // If character is jumping do the jump animation
        // Otherwise, do idle
        if ((GetComponent<Player2Controls>().moveDirection) != 0 && GetComponent<Player2Controls>().isGrounded)
        {
            characterAnimator.Play("Sprint Animation");
        } else if (!GetComponent<Player2Controls>().isGrounded)
        {
            characterAnimator.Play("Jump Animation");
        } else
        {
            characterAnimator.Play("Idle Animation");
        }
    }
}
