using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconBar : MonoBehaviour {

    public Image[] Icons;

    public Color EnabledColor;
    public Color DisabledColor;

    private int _value;
    public int Value {
        get
        {
            return _value;
        }
        set
        {
            _value = Mathf.Min(Icons.Length, value);
            for (int i = 0; i < _value; i++)
                Icons[i].color = EnabledColor;
            for (int i = Icons.Length-_value; i < _value; i++)
                Icons[i].color = DisabledColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
