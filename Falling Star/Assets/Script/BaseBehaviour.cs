using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BaseBehaviour : MonoBehaviour
{

    internal void OnHandlerMessage(ObservParam observParam, Action<ObservParam> value)
    {
        value(observParam);
    }
}