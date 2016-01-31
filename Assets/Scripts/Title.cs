using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace GlobalGameJam16 {
    public class Title: MonoBehaviour {
        public void Update() {
            if (Input.GetButtonDown("Jump")) {
                SceneManager.LoadScene("temple");
            }
        }
    }
}