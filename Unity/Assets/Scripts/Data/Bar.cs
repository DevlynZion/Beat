using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Bar 
{
    public List<Beat> Beats;

    public Bar()
    {
        Beats = new List<Beat>();
    }
}
