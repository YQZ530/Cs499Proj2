using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMessage 
{
    UnityAction<string> message { get; set; }
}
