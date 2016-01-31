using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GlobalGameJam16 {
    public class Prayer: MonoBehaviour {
        public InputField input;
        public Text goalLabel;
        public string goalText;

        [HideInInspector]
        public PrayerScroll scroll;

        public void Start() {
            input.onValueChanged.AddListener(delegate { ValueChanged(); });
            input.onEndEdit.AddListener(delegate { EditCancelled(); });
            input.Select();
            input.ActivateInputField();
            UpdateGoalLabel();
            GameDriver.Instance.OnTextEntryStart();
        }
        public void ValueChanged() {
            UpdateGoalLabel();
        }
        public void EditCancelled() {
            PrayerFail();
        }

        private void PrayerFail() {
            GameDriver.Instance.OnTextEntryFinish();
            Destroy(gameObject);
        }
        private void PrayerSuccess() {
            StartCoroutine(_prayerSuccess());
        }
        private IEnumerator _prayerSuccess() {
            scroll.OnPrayerSuccess();
            input.text = "<color=green><b>" + goalText + "</b></color>";
            input.readOnly = true;
            yield return new WaitForSeconds(1f);
            GameDriver.Instance.OnTextEntryFinish();
            Destroy(gameObject);
        }
        /// <summary>
        /// Updates goalLabel based on what user has typed
        /// </summary>
        public void UpdateGoalLabel() {
            string newLabel = "";
            int matchLength;

            // strip out any newlines if they hit enter
            input.text = input.text.Replace("\n", "");

            for (matchLength = 0; matchLength < goalText.Length && matchLength < input.text.Length; matchLength++) {
                if (goalText[matchLength] != input.text[matchLength]) {
                    break;
                }
            }
            if (matchLength == goalText.Length) {
                newLabel = "<color=green><b>" + goalText + "</b></color>";
                PrayerSuccess();
            } else {
                // if matchLength is less than what they've typed, 
                // there's an error.  Highlight it in the goalText.
                if (matchLength < input.text.Length) {
                    int numErrors = input.text.Length - matchLength;
                    int numGoalErrors = Mathf.Min(numErrors, goalText.Length - matchLength);
                    newLabel = goalText.Substring(0, matchLength);
                    newLabel += "<color=red><b>";
                    newLabel += goalText.Substring(matchLength, numGoalErrors).Replace(' ', '_');
                    newLabel += "</b></color>";
                    if (matchLength + numErrors < goalText.Length) {
                        newLabel += goalText.Substring(matchLength + numErrors);
                    }
                } else {
                    // no errors, not done.  highlight next character.
                    newLabel = goalText.Substring(0, matchLength);
                    newLabel += "<color=green><b>";
                    string nextChar = goalText.Substring(matchLength, 1);
                    if (nextChar[0] == ' ') {
                        nextChar = " ";
                    }
                    newLabel += nextChar;
                    newLabel += "</b></color>";
                    if (matchLength + 1 < goalText.Length) {
                        newLabel += goalText.Substring(matchLength + 1);
                    }
                }
            }
            if (newLabel != "") {
                goalLabel.text = newLabel;
            }
        }
    }
}