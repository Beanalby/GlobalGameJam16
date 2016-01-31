using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class BroomPut: MonoBehaviour {
        public GameObject broom;
        public BroomGet get;

        public void UseThing(ThingUser user) {
            user.RemoveEquipment();
            broom.transform.parent = transform.parent;
            broom.transform.localPosition = new Vector3(0, 1, 0);
            broom.transform.localRotation = Quaternion.identity;
            broom.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
            get.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}