using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class Dirt: MonoBehaviour {
        public void UseThing(ThingUser user) {
            SendMessage("ClearUsableThing");
            Destroy(gameObject);
        }
    }
}
