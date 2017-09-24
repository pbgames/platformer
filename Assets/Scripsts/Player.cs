using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private Rigidbody2D rigidbody;
  private Animator animator;

  [SerializeField]
  private float movementSpeed;

  private bool facingRight;

  void Start() {
    rigidbody = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();

    facingRight = true;
  }

  void FixedUpdate() {
    float horizontal = Input.GetAxis("Horizontal");

    HandleMovement(horizontal);
    Flip(horizontal);
  }

  private void HandleMovement(float horizontal) {
    rigidbody.velocity = new Vector2(horizontal * movementSpeed, rigidbody.velocity.y);
    animator.SetFloat("speed", Mathf.Abs(horizontal));
  }

  private void Flip(float horizontal) {
    if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
      facingRight = !facingRight;

      Vector3 scale = transform.localScale;
      scale.x *= -1;
      transform.localScale = scale;
    }
  }
}
