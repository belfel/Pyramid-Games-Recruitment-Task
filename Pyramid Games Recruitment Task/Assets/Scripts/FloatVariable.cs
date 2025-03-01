using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Scriptable Objects/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    public GameEvent valueChanged;
    public float value;

    public void SetValue(float _value)
    {
        if (value != _value && valueChanged != null)
            valueChanged.Raise();
        value = _value;
    }
}
