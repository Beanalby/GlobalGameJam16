using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class Player: MonoBehaviour {
        private float moveSpeed = 3f;

        Rigidbody2D rb;

        public void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Update() {
            rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
        }
    }
}