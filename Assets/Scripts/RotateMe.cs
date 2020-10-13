using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * (speed * Time.deltaTime));
    }
}
