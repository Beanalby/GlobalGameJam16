using UnityEngine;
using System.Collections;

namespace GlobalGameJam16 {
    public class GameDriver: MonoBehaviour {
        static private GameDriver _instance = null;
        static public GameDriver Instance {
            get {
                if (_instance == null) {
                    Debug.LogError("!!! No gamedriver found!");
                }
                return _instance;
            }
        }

        private bool canControl = true;
        public bool CanControl { get { return canControl; } }

        public void Start() {
            if (_instance != null) {
                Debug.LogError("!!! multiple gameDrivers!");
                Destroy(gameObject);
                return;
            }
            _instance = this;
        }


        public void OnTextEntryStart() {
            canControl = false;
        }
        public void OnTextEntryFinish() {
            canControl = true;
        }
    }
}