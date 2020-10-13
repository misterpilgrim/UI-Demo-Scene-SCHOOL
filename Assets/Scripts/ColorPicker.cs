using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    [SerializeField]
    private Material currentMat;

    // color material references
    [SerializeField]
    private Material pink;
    [SerializeField]
    private Material blue;
    [SerializeField]
    private Material purple;
    [SerializeField]
    private Material green;
    [SerializeField]
    private Material yellow;

    [SerializeField]
    private List<Material> colors;
    int currentColor;

    // Start is called before the first frame update
    void Start()
    {
        currentMat = gameObject.GetComponent<Renderer>().material;
        currentColor = 0;

        colors = new List<Material>()
        {
            blue,
            purple,
            green,
            yellow,
            pink,
        };
    }

    public void ChangeColor()
    {
        Material newColor;
        
        if (currentColor == colors.Count) currentColor = 0;
        newColor = colors[currentColor];
        currentMat = newColor;
        gameObject.GetComponent<Renderer>().material = currentMat;
        currentColor++;
    }
}
