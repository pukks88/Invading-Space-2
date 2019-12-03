﻿using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class InvaderWaveList : SerializedScriptableObject
{
    public List<InvaderWave> invaderWaves;

    public InvaderWave GetInvaderWave(int rows =4)
    {
        if (rows > 10 || rows < 1)
        {
            return null;
        }
        return invaderWaves[rows - 1];
    }
}