using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GlobalGameJam16 {
    public class FadeOut: MonoBehaviour {
        public Image background;

        private float timeStart, fadeDuration = 1f;

        public void Start() {
            timeStart = Time.time;
        }

        public void Update() {
            float percent = (Time.time - timeStart) / fadeDuration;
            if (percent >= 1) {
                GameState.Instance.FadeOutFinished();
            } else {
                background.color = new Color(1, 1, 1, percent);
            }
        }
    }
}