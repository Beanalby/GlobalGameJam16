using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class UsableThing: MonoBehaviour {
        public string description;
        public GameObject requiredEquipment;

        private GameObject user;
        public void OnTriggerEnter2D(Collider2D other) {
            user = other.gameObject;
            user.SendMessage("SetUsableThing", this, SendMessageOptions.DontRequireReceiver);
        }
        public void OnTriggerExit2D(Collider2D other) {
            ClearUsableThing();
        }
        public void ClearUsableThing() {
            user.SendMessage("ClearUsableThing", SendMessageOptions.DontRequireReceiver);
        }
    }
}