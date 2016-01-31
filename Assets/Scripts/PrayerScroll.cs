using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class PrayerScroll: MonoBehaviour {
        public GameObject prayerPrefab;
        public string prayerText;
        private bool isQuitting = false;

        private bool wasPrayed = false;

        public void UseThing(ThingUser user) {
            GameObject obj = Instantiate(prayerPrefab);
            Prayer prayer = obj.GetComponent<Prayer>();
            prayer.scroll = this;
            prayer.goalText = prayerText;
            SendMessage("ClearUsableThing");
        }

        public void OnPrayerSuccess() {
            if (wasPrayed == false) {
                wasPrayed = true;
                GameState.Instance.PrayedScroll();
            }
        }

        public void OnApplicationQuit() {
            isQuitting = true;
        }
        public void OnDestroy() {
            if (!isQuitting && !wasPrayed) {
                GameState.Instance.UnprayedScroll();
            }
        }
    }
}