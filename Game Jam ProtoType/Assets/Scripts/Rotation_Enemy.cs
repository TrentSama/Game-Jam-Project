using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Enemy : MonoBehaviour {

    private GameObject thingToRotate;
    private Transform target;
    private Vector3 _dir;




    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
    }
}
