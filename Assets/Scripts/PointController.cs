using UnityEngine;

public class PointController : MonoBehaviour
{
    public static PointController Instance;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        if (Instance != null && Instance != this)
            Destroy(Instance);
    }

    private int _pointCount = 0;

    public void UpdatePoint(int point)
    {
        _pointCount += point;
    }
}