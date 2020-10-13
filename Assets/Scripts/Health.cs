using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int hp;
    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }
    [SerializeField]
    private int maxVal;
    public int MaxHP
    {
        get { return maxVal; }
    }
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Image barImage;
    [SerializeField]
    private Text deathText;

    // Start is called before the first frame update
    void Start()
    {
        maxVal = 400;
        hp = maxVal;
        healthBar.maxValue = maxVal;
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        // change healthbar color
        if (hp > maxVal / 2) barImage.color = Color.green;
        else if (hp > maxVal / 5 && hp <= maxVal / 2) barImage.color = Color.yellow;
        else if (hp <= maxVal / 5) barImage.color = Color.red;

        // toggle death message
        if (hp <= 0) deathText.enabled = true;
        else deathText.enabled = false;

    }

    public void TakeDamage(int dmg)
    {
        if (hp - dmg <= 0) hp = 0;
        else hp -= dmg;

        UpdateSlider();
    }

    public void RestoreDamage(int rst)
    {
        if (hp + rst >= maxVal) hp = maxVal;
        else hp += rst;

        UpdateSlider();
    }

    public void UpdateSlider()
    {
        healthBar.value = hp;
    }
}
