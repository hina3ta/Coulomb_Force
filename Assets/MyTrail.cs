using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrail : MonoBehaviour {
    GameObject[] go_list;
    void Start() {
        go_list = GameObject.FindGameObjectsWithTag("Player");
        transform.position = Random.onUnitSphere * 40f;
        GetComponent<Rigidbody>().AddForce(Vector3.Cross(transform.position, Random.onUnitSphere), ForceMode.Impulse);
    }

    void FixedUpdate() {
        foreach (var go in go_list) {
            if (go.GetInstanceID() != gameObject.GetInstanceID()) {
                var diff = go.transform.position - transform.position;
                var len2 = diff.sqrMagnitude;
                var force = diff.normalized / len2;
                GetComponent<Rigidbody>().AddForce(force * 1000f);
            }
        }
        GetComponent<Rigidbody>().AddForce(-transform.position * 0.1f);
    }
}
