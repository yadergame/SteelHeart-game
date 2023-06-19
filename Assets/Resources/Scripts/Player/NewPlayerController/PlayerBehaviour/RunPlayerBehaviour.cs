using UnityEngine;

public class RunPlayerBehaviour : MonoBehaviour, IPlayerBehaviour
{
    public bool IsActive { get; private set; } //activity behavior
    public IPlayerBehaviourData PlayerData { get; private set; } //player data

    [SerializeField] private PlayerMove _playerMove; //player movement

    private void Awake()
    {
        PlayerData = GetComponent<IPlayerBehaviourData>(); //receiving IPlayerBehaviourData
    }

    public void EnterBehaviour()
    {
        IsActive = true;
    }
    public void UpdateBehaviour()
    {
        Run(); //player run
    }
    public void ExitBehaviour()
    {
        IsActive = false;
    }

    private void Run()
    {
        if (_playerMove != null)
            _playerMove.MovePlayer(PlayerData.Z, PlayerData.X, PlayerData.SpeedPlayer, PlayerData, 0);
    }
}