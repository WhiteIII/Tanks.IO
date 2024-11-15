public class Retreat : IRule
{
    public bool CanExacute => _aiAgent.HasEnemy
                            && _aiAgent.CloseEnougthToAttack
                            && _aiAgent.HealthCriticalValue;

    private readonly AiAgent _aiAgent;

    public Retreat(AiAgent aiArent) =>
        _aiAgent = aiArent;

    public void Execute()
    {
        _aiAgent.MoveAwayFromEnemy();
    }
}
