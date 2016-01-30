using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class Player: MonoBehaviour {
        public GameObject PrayerPrefab;
        
        private float moveSpeed = 3f;

        Rigidbody2D rb;

        public void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Update() {
            if (!GameDriver.Instance.CanControl) {
                rb.velocity = Vector2.zero;
            } else {
                rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
            }
        }
    }
}