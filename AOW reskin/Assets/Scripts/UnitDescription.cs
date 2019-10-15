using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Unit Description")]
public class UnitDescription : ScriptableObject
{
    [SerializeField] public int UnitPrice;
    [SerializeField] public int UnitDamage;
    [SerializeField] public int UnitRange;
    [SerializeField] public string UnitText;
}
