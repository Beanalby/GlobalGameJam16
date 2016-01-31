using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GlobalGameJam16 {
    public class Pulser: MonoBehaviour {
        public Image img;
        Color c;

        public void Start() {
            c = img.color;
            UpdateColor();
        }
        public void Update() {
            UpdateColor();
        }
        private void UpdateColor() {
            c.a = (Mathf.Sin(Time.time*4) + 1) / 2f;
            img.color = c;
        }
    }
}