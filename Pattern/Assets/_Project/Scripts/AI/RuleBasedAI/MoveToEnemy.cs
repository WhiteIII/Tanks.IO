public class MoveToEnemy : IRule
{
    public bool CanExacute => _aiAgent.HasEnemy 
                                && !_aiAgent.CloseEnougthToAttack
                                && !_aiAgent.HealthCriticalValue;

    private readonly AiAgent _aiAgent;

    public MoveToEnemy(AiAgent aiAgent) =>
        _aiAgent = aiAgent;

    public void Execute()
    {
        _aiAgent.MoveToEnemy();
    }
}
