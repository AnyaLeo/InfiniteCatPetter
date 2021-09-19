using UnityEngine;
using System;

public class Events : Singleton<Events>
{
    public Action LevelIncreased;
    public Action<float> CatHappinessChanged;
    public Action CatHairSold;
}
