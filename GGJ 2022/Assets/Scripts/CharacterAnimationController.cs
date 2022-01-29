using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator characterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If character is running, do the sprint animation
        // If character is jumping do the jump animation
        // Otherwise, do idle
        if ((GetComponent<PlayerControls>().moveDirection) != 0 && GetComponent<PlayerControls>().isGrounded)
        {
            characterAnimator.Play("Sprint Animation");
        } else if (!GetComponent<PlayerControls>().isGrounded)
        {
            characterAnimator.Play("Jump Animation");
        } else
        {
            characterAnimator.Play("Idle Animation");
        }
        
    }
}
