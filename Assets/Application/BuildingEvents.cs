using System;
using UnityEngine;

public static class BuildingEvents
{
    public static event Action OnBuildingChanged;
    
    public static void NotifyBuildingChanged()
    {
        OnBuildingChanged?.Invoke();
    }
}