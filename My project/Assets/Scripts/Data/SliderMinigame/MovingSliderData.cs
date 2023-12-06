using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MovingSliderData", order = 1)]
public class MovingSliderData : ScriptableObject
{
   public float speed;
   public float visualInit;
   public float visualEnd;
   public float valueInint;
   public float valueEnd;

}
