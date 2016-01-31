using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

namespace GlobalGameJam16 {
    public class GameState: MonoBehaviour {
        static private GameState _instance;
        static public GameState Instance {
            get {
                if (_instance == null) {
                    Debug.LogError("!!! No static GameState found!");
                    Debug.Break();
                }
                return _instance;
            }
        }

        public GameObject dirtPrefab, fadeOutPrefab;

        private int endDay = 3, currentDay = 1;
        public int CurrentDay { get { return currentDay; } }

        private int numNewDirt = 3, numDirtFailed=0, numDirtSucceeded,
            numPrayFailed=0, numPraySucceeded=0,
            numStatueFailed=0, numStatueSucceeded=0;
        private Rect dirtRange = new Rect(-.5f, -2f, 12f, 2.5f);
        private HashSet<Vector3> dirtSpots;
        public int NumDirtFailed { get { return numDirtFailed; } }
        public int NumPrayFailed { get { return numPrayFailed; } }
        public int NumDirtSucceeded { get { return numDirtSucceeded; } }
        public int NumPraySucceeded { get { return numPraySucceeded; } }
        public int NumStatueFailed { get { return numStatueFailed; } }
        public int NumStatueSucceeded { get { return numStatueSucceeded; } }

        public void Awake() {
            if (_instance != null) {
                // GameState already exists from previously loaded stage,
                // which is fine.
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
            dirtSpots = new HashSet<Vector3>();
        }
        public void Start() {
            SpawnNewDirt();
        }

        public void OnLevelWasLoaded(int level) {
            // gets called even if we're a duplicate that's going
            // to be destroyed, make sure we're the real one
            if (_instance != this) {
                return;
            }
            if (currentDay == 1) {
                // nothing to do on day 1
                return;
            } else if (currentDay == endDay) {
                // don't spawn new stuff, just note things undone
                numDirtFailed += dirtSpots.Count;
            } else {
                RestoreDirt();
                SpawnNewDirt();
            }
        }

        public void AddDirt(Vector3 pos) {
            dirtSpots.Add(pos);
        }
        public void RemoveDirt(Vector3 pos) {
            dirtSpots.Remove(pos);
            ++numDirtSucceeded;
        }
        private void SpawnDirt() {
            Vector3 pos = new Vector3(
                Random.Range(dirtRange.min.x, dirtRange.max.x),
                Random.Range(dirtRange.min.y, dirtRange.max.y),
                0);
            SpawnDirt(pos);
        }
        private void SpawnDirt(Vector3 pos) {
            Instantiate(dirtPrefab, pos, Quaternion.identity);
            AddDirt(pos);
        }
        private void SpawnNewDirt() {
            for (int i = 0; i < numNewDirt; i++) {
                SpawnDirt();
            }
        }
        private void RestoreDirt() {
            foreach (Vector3 pos in dirtSpots) {
                ++numDirtFailed;
                SpawnDirt(pos);
            }
        }

        public void CleanedDirt() {
            ++numDirtSucceeded;
        }
        public void PrayedScroll() {
            ++numPraySucceeded;
        }
        public void UnprayedScroll() {
            ++numPrayFailed;
        }
        public void PolishedStatue() {
            ++numStatueSucceeded;
        }
        public void UnpolishedStatue() {
            ++numStatueFailed;
        }

        public void AdvanceDay() {
            Instantiate(fadeOutPrefab);
        }
        public void FadeOutFinished() {
            ++currentDay;
            if (currentDay == endDay) {
                SceneManager.LoadScene("EndDay");
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}