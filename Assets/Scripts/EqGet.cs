using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class EqGet: MonoBehaviour {
        public GameObject equipment;

        public void UseThing(ThingUser user) {
            user.AddEquipment(equipment);
            SendMessage("ClearUsableThing");
        }
    }
}