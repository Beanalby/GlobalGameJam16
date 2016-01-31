using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("+++ exiing");
    }
}
