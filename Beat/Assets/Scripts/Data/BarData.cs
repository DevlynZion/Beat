using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BarData 
{
    public List<BeatData> Beats;

    public BarData()
    {
        Beats = new List<BeatData>();
    }
}
