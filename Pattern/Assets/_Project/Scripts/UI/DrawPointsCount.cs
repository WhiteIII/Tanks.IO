using TMPro;
using UnityEngine;
using Zenject;

public class DrawPointsCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _points;
    [SerializeField] private TextMeshProUGUI _level;

    [Inject] private PlayerData _playerData;

    private void Awake()
    {
        _points.text = "0";
        _level.text = "0";
        _playerData.PointsCountChange += DrawPoints;
        _playerData.LevelChange += DrawLevel;
    }

    private void OnDestroy()
    {
        _playerData.PointsCountChange -= DrawPoints;
        _playerData.LevelChange -= DrawLevel;
    }

    private void DrawPoints()
    {
        _points.text = _playerData.CountOfPoints.ToString();
    }

    private void DrawLevel()
    {
        _level.text = _playerData.Level.ToString();
    }
}
