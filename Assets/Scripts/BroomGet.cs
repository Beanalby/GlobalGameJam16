using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class BroomGet: MonoBehaviour {
        public GameObject broom;
        public BroomPut put;

        public void UseThing(ThingUser user) {
            user.AddEquipment(broom);
            put.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}