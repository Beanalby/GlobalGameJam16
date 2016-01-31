using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace GlobalGameJam16 {
    public class Exit: MonoBehaviour {
        public void OnTriggerEnter2D(Collider2D other) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}