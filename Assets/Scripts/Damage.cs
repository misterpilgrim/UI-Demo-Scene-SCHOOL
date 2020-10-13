using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private Image hurtBlur;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = player.GetComponent<Health>();
        hurtBlur = GameObject.Find("Damage").GetComponent<Image>();
        hurtBlur.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health.TakeDamage(2);
            if (health.HP > 0) hurtBlur.enabled = true;
            else hurtBlur.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hurtBlur.enabled = false;
        }
    }
}
