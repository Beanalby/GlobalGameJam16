using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class Exit: MonoBehaviour {
        public void OnTriggerEnter2D(Collider2D other) {
            GameState.Instance.AdvanceDay();
        }
    }
}