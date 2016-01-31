using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GlobalGameJam16 {
    public class FadeIn: MonoBehaviour {
        public Text label;
        public Image background;
        
        private float timeStart, fadeDelay = 1f, fadeDuration = 1f;

        public void Start() {
            background.enabled = true;
            timeStart = Time.time;
            label.text = "Day " + GameState.Instance.CurrentDay;
        }

        public void Update() {
            float pos = Time.time - timeStart;
            if (pos < fadeDelay) {
                return;
            }
            pos -= fadeDelay;
            float percent = pos / fadeDuration;
            if (percent >= 1) {
                Destroy(gameObject);
                return;
            } else {
                background.color = new Color(1, 1, 1, 1-percent);
            }
        }
    }
}