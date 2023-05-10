using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    AnimatorManager animatorManager;
    Animator animator;
    
    public CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;

    public bool isInteracting;
    public int health;

    private void Awake()
    {
        health = 15;
        animatorManager = GetComponent<AnimatorManager>();
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        //cameraManager = GetComponent<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();

        if (Input.GetKeyDown(KeyCode.P))
        {
            
            animator.Play("Dance");
            
        }

    }

    public void DoDamage()
    {
        Debug.Log(health);
        health = health - 1;
        animatorManager.PlayTargetAnimation("GetHit", false);
        health = health - 1;
        if (health < 0)
        {
            transform.position = new UnityEngine.Vector3(0, 10, 0);
            health = 15;
        }
        
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();

        isInteracting = animator.GetBool("isInteracting");
        playerLocomotion.isJumping = animator.GetBool("isJumping");
        animator.SetBool("isGrounded",playerLocomotion.isGrounded);
    }
}
