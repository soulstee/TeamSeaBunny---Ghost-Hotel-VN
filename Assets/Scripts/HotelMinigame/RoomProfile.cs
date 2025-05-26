using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomProfile", menuName = "Hotel/Room Profile")]
public class RoomProfile : ScriptableObject
{
    public string roomType;
    public string bedType;
    public string keyItemA;
    public string keyItemB;
}
