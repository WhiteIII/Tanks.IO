using DG.Tweening;
using UnityEngine;
using Zenject;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private int _tweenersCapacity = 2000;
    [SerializeField] private int _sequencesCapacity = 100;
    
    private PlayerData _playerData;
    private GameRules _gameRules;

    [Inject] private void Construct(PlayerData playerData, GameRules gameRules)
    {
        _playerData = playerData;
        _gameRules = gameRules;

        _playerData.PlayerDataLoad();
        _gameRules.Init();

        DOTween.SetTweensCapacity(_tweenersCapacity, _sequencesCapacity);
    }

    private void OnDestroy()
    {
        _playerData.ResetThePoints();
        _playerData.ResetStats();
    }
}
