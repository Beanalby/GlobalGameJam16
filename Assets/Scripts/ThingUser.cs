﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GlobalGameJam16 {
    public class ThingUser: MonoBehaviour {
        private GameObject equipment = null;

        private UsableThing thing = null;

        public GameObject thingDesc;
        public Text thingDescLabel;
        public bool SpecializedThing = false;

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
            // check if the usable thing requires equipment
            if (newThing.requiredEquipment != null && newThing.requiredEquipment != equipment) {
                return;
            }
            thing = newThing;
            thingDescLabel.text = thing.description;
            thingDesc.SetActive(true);
        }

        public void ClearUsableThing() {
            thing = null;
            thingDesc.SetActive(false);
        }

        public void AddEquipment(GameObject newEq) {
            equipment = newEq;
            equipment.GetComponentInChildren<SpriteRenderer>().sortingOrder = 10;
            equipment.transform.parent = transform;
            equipment.transform.localPosition = new Vector3(0.29f, -.07f, 0);
            equipment.transform.localRotation = Quaternion.Euler(0, 0, 323);
        }
        public void RemoveEquipment() {
            equipment = null;
        }

    }
}