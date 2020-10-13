using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftCam : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRot;
    [SerializeField]
    private float minRot;
    private Quaternion target;
    [SerializeField]
    private bool canRotate;
    [SerializeField]
    private KeyCode left;
    [SerializeField]
    private KeyCode right;

    // Start is called before the first frame update
    void Start()
    {
        target = Quaternion.Euler(40,0,0);
        speed = 60f;
        maxRot = 20f;
        minRot = -20f;
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left) && Input.GetKey(right)) StartCoroutine(ResetPosition());
        
        // if centering camera don't accept rotate input
        if (!canRotate) return;

        else if (Input.GetKey(left))
        {
            cam.transform.RotateAround(cam.transform.position, Vector3.down, speed * Time.deltaTime);
        }
        else if (Input.GetKey(right))
        {
            cam.transform.RotateAround(cam.transform.position, Vector3.up, speed * Time.deltaTime);
        }
    }

    IEnumerator ResetPosition()
    {
        canRotate = false;
        cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, target, 2 * (speed * Time.deltaTime));
        yield return new WaitForSeconds(2.0f);
        canRotate = true;
    }
}
