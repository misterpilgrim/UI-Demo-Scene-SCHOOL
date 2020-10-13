using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool moving;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private KeyCode forward;
    [SerializeField]
    private KeyCode left;
    [SerializeField]
    private KeyCode back;
    [SerializeField]
    private KeyCode right;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        moving = false;
        particle = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(forward)) transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        if (Input.GetKey(left)) transform.Translate(Vector3.left * (speed * Time.deltaTime));
        if (Input.GetKey(back)) transform.Translate(Vector3.back * (speed * Time.deltaTime));
        if (Input.GetKey(right)) transform.Translate(Vector3.right * (speed * Time.deltaTime));

        if (Input.GetKey(forward) || Input.GetKey(left) || Input.GetKey(back) || Input.GetKey(right)) moving = true;
        else moving = false;
    }
}
