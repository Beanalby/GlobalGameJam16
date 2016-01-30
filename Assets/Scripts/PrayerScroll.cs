using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class PrayerScroll: MonoBehaviour {
        public GameObject prayerPrefab;
        public string prayerText;

        public void UseThing(ThingUser user) {
            GameObject obj = Instantiate(prayerPrefab);
            Prayer prayer = obj.GetComponent<Prayer>();
            prayer.goalText = prayerText;
            SendMessage("ClearUsableThing");
        }
    }
}