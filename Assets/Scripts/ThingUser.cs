using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GlobalGameJam16 {
    public class ThingUser: MonoBehaviour {
        private UsableThing thing = null;
        public GameObject thingDesc;
        public Text thingDescLabel;

        public void Start() {
            ClearUsableThing();
        }

        public void Update() {
            if (GameDriver.Instance.CanControl) {
                if (Input.GetButtonDown("Jump")) {
                    thing.SendMessage("UseThing", this);
                }
            }
        }

        public void SetUsableThing(UsableThing newThing) {
            thing = newThing;
            thingDescLabel.text = thing.description;
            thingDesc.SetActive(true);
        }

        public void ClearUsableThing() {
            thing = null;
            thingDesc.SetActive(false);
        }
    }
}