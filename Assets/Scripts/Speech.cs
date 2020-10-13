using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speech : MonoBehaviour
{
    [SerializeField]
    private Text speech;
    [SerializeField]
    private SpriteRenderer bubble;
    [SerializeField]
    private KeyCode talk;
    [SerializeField]
    List<string> sayings;
    private bool talking;

    // Start is called before the first frame update
    void Start()
    {
        bubble = GameObject.Find("Bubble").GetComponent<SpriteRenderer>();
        speech = bubble.transform.Find("Dialog").GetComponent<Text>();
        talking = false;
        sayings = new List<string>()
        {
            "Checkaroony!",
            "Can I get a 100 on this project?",
            "Have you ever tried fish cakes?",
            "Josh is totally the coolest.",
            "But thou must!",
            "What is a turnip sandwich?",
            "I don't know what I'm doing!",
            "You should play Dragon Quest.",
            "What time is it?",
            "Ogres are like onions!",
            "Hi Sam!",
            "Soup, soup, make ya poop!",
            "Hello world!",
            "L is real!",
            "Procrastination!",
        };

        // set text as empty to start
        speech.text = "";
        bubble.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(talk) && !talking) StartCoroutine(Talk());
    }

    IEnumerator Talk()
    {
        // choose a phrase
        talking = true;
        speech.text = sayings[Random.Range(0, sayings.Count)];
        bubble.enabled = true;

        // display text for a couple seconds
        yield return new WaitForSeconds(2.0f);

        // stop talking, clear text
        bubble.enabled = false;
        speech.text = "";
        talking = false;
    }

}
