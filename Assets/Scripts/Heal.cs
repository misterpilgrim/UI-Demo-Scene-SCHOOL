using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    [SerializeField]
    private Image healBlur;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = player.GetComponent<Health>();
        healBlur = GameObject.Find("Heal").GetComponent<Image>();
        healBlur.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health.RestoreDamage(2);
            if (health.HP < health.MaxHP) healBlur.enabled = true;
            else healBlur.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healBlur.enabled = false;
        }
    }
}
