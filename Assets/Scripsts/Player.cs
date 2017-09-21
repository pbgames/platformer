using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private Rigidbody2D rigidbody;

  [SerializeField]
  private float movementSpeed;

  private bool facingRight;

  void Start() {
    facingRight = true;
    rigidbody = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    float horizontal = Input.GetAxis("Horizontal");

    HandleMovement(horizontal);
    Flip(horizontal);
  }

  private void HandleMovement(float horizontal) {
    rigidbody.velocity = new Vector2(horizontal * movementSpeed, rigidbody.velocity.y);
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
