using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class EqPut: MonoBehaviour {
        public GameObject equipment;

        public void UseThing(ThingUser user) {
            user.RemoveEquipment();
            equipment.transform.parent = transform.parent;
            equipment.transform.localPosition = new Vector3(0, 1, 0);
            equipment.transform.localRotation = Quaternion.identity;
            equipment.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
            SendMessage("ClearUsableThing");
        }
    }
}