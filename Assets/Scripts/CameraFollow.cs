using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject target;
    float maxPosition;
    float minPosition;

    public void FixedUpdate() {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, target.transform.position.x, 0.02f),
            transform.position.y,
            transform.position.z);
    }
}
