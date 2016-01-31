using UnityEngine;
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

        public GameObject dirtPrefab;

        private int numNewDirt = 3, numUncleanedDirt=0, numUnprayed=0;
        private Rect dirtRange = new Rect(-.5f, -2f, 12f, 2.5f);
        private HashSet<Vector3> dirtSpots;

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
            RestoreDirt();
            SpawnNewDirt();
        }

        public void AddDirt(Vector3 pos) {
            dirtSpots.Add(pos);
        }
        public void RemoveDirt(Vector3 pos) {
            dirtSpots.Remove(pos);
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
                ++numUncleanedDirt;
                SpawnDirt(pos);
            }
        }

        public void UnprayedScroll() {
            ++numUnprayed;
        }
    }
}