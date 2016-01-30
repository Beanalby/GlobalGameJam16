using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Prayer : MonoBehaviour {
    public InputField input;
    public Text goalLabel;
    public string goalText;
    
    public void Start() {
        input.onValueChanged.AddListener(delegate { ValueChanged(); });
        input.Select();
        input.ActivateInputField();
        UpdateGoalLabel();
    }

    public void ValueChanged() {
        UpdateGoalLabel();
    }

    private void PrayerFail() {
    }
    private void PrayerSuccess() {
    }

    /// <summary>
    /// Updates goalLabel based on what user has typed
    /// </summary>
    public void UpdateGoalLabel() {
        string newLabel="";
        int matchLength;
        for (matchLength = 0; matchLength < goalText.Length && matchLength < input.text.Length; matchLength++) {
            if (goalText[matchLength] != input.text[matchLength]) {
                break;
            }
        }
        Debug.Log("+++ matchLength=" + matchLength);
        if (matchLength == goalText.Length) {
            Debug.Log("+++ success!");
        } else {
            // if matchLength is less than what they've typed, 
            // there's an error.  Highlight it in the goalText.
            if (matchLength < input.text.Length) {
                int numErrors = input.text.Length - matchLength;
                newLabel = goalText.Substring(0, matchLength);
                newLabel += "<color=red><b>";
                newLabel += goalText.Substring(matchLength, numErrors).Replace(' ', '_');
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
        Debug.Log("newLabel=" + newLabel);
        if (newLabel != "") {
            goalLabel.text = newLabel;
        }
    }
}
