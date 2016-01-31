using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class Statue: MonoBehaviour {

        private bool wasPolished = false;
        private bool isQuitting = false;

        public void UseThing(ThingUser user) {
            SendMessage("ClearUsableThing");
            if (!wasPolished) {
                wasPolished = true;
                GameState.Instance.PolishedStatue();
            }
        }

       public void OnApplicationQuit() {
            isQuitting = true;
        }
        public void OnDestroy() {
            if (!isQuitting && !wasPolished) {
                GameState.Instance.UnpolishedStatue();
            }
        }
     }
}