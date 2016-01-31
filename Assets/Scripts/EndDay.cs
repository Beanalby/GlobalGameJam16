﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GlobalGameJam16 {
    public class EndDay: MonoBehaviour {
        public GameObject tehlu, devil;

        public Text endLabel;
        public Image badImage;
        private float threshold = .6f;

        public void Start() {
            GameState state = GameState.Instance;
            bool dirtFailed = ((float)state.NumDirtSucceeded / (state.NumDirtFailed + state.NumDirtSucceeded)) < threshold;
            bool prayFailed = ((float)state.NumPraySucceeded / (state.NumPrayFailed + state.NumPraySucceeded)) < threshold;
            bool statueFailed = ((float)state.NumStatueSucceeded / (state.NumStatueFailed + state.NumStatueSucceeded)) < threshold;
            string labelText = "";
            if (dirtFailed) {
                labelText += "Your negligence in cleaning the temple has made Tehlu angry.\n\n";
            }
            if (prayFailed) {
                labelText += "Skipping your prayers has left Tehlu weak and abandoned.\n\n";
            }
            if (statueFailed) {
                labelText += "Ignoring Tehlu's statues has tarnished his image.\n\n";
            }
            if (prayFailed || dirtFailed || statueFailed) {
                devil.SetActive(true);
                tehlu.SetActive(false);
                labelText += "The world falls into ruins.";
                badImage.gameObject.SetActive(true);
            } else {
                devil.SetActive(false);
                tehlu.SetActive(true);
                labelText += "Your dilligence has delivered salvation to the world.";
            }
            endLabel.text = labelText;
        }
    }
}