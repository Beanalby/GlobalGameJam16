using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GlobalGameJam16 {
    public class EndDay: MonoBehaviour {
        public Text endLabel;

        public void Start() {
            GameState state = GameState.Instance;
            string dirtStat = state.NumDirtFailed + "/" + (state.NumDirtFailed + state.NumDirtSucceeded);
            string prayStat = state.NumPrayFailed + "/" + (state.NumPrayFailed + state.NumPraySucceeded);
            endLabel.text = "You cleaned " + dirtStat + " dirt and prayed " + prayStat + " scrolls.";
        }
    }
}