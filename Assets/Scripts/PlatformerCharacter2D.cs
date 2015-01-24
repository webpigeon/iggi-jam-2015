﻿using UnityEngine;

    public class PlatformerCharacter2D : MonoBehaviour
    {
        private bool facingRight = true; // For determining which way the player is currently facing.

        [SerializeField]
        private float maxSpeed = 10f; // The fastest the player can travel in the x axis.
        [SerializeField]
        private float jumpForce = 150f; // Amount of force added when the player jumps.	

        [SerializeField]
        private bool airControl = false; // Whether or not a player can steer while jumping;
        [SerializeField]
        private LayerMask whatIsGround; // A mask determining what is ground to the character

        private Transform groundCheck; // A position marking where to check if the player is grounded.
        private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool grounded = false; // Whether or not the player is grounded.
        private Transform ceilingCheck; // A position marking where to check for ceilings
        private float ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator anim; // Reference to the player's animator component.
        public bool doorKey = false;

        public float minX = -9;    // Allowable range for player before telporting to other side
        public float maxX =  9;
        public float minY = -5.3f;
        public float maxY =  5.3f;
        private float rangeX;
        private float rangeY;

        public bool forcePosition = false;
        public Vector3 forcePositionVector;

        private void Awake() {
            groundCheck = transform.Find("GroundCheck");
            ceilingCheck = transform.Find("CeilingCheck");
            anim = GetComponent<Animator>();
        }

        private void Start() {
            rangeX = (maxX - minX);
            rangeY = (maxY - minY);
        }

        private void FixedUpdate() {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
            anim.SetBool("Ground", grounded);
            anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

            if (forcePosition) {
                rigidbody2D.isKinematic = true;
                rigidbody2D.transform.position = forcePositionVector;
                rigidbody2D.isKinematic = false;
                forcePosition = false;
            }
        }


        public void Move(float move, bool crouch, bool jump) {
            if (grounded || airControl) {
                anim.SetFloat("Speed", Mathf.Abs(move));
                rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
                if (move > 0 && !facingRight)
                    Flip();
                else if (move < 0 && facingRight)
                    Flip();
            }

            if (grounded && jump && anim.GetBool("Ground")) {
                grounded = false;
                anim.SetBool("Ground", false);
                rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            }

            Vector3 newPosition = transform.position;
            if (transform.position.x < minX) {
                newPosition.x += rangeX;
            } else if (transform.position.x > maxX) {
                newPosition.x -= rangeX;
            }

            if (transform.position.y < minY) {
                newPosition.y += rangeY;
            } else if (transform.position.y > maxY) {
                newPosition.y -= rangeY;
            }

            transform.position = newPosition;
        }

        public void AdjustMove(float move) {
            rigidbody2D.velocity = new Vector2(move, rigidbody2D.velocity.y);
        }


        private void Flip() {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        public bool Key {
            get { return doorKey; }
            set { doorKey = value; }
        }

    
}