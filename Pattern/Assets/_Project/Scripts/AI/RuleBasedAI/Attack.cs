public class Attack : IRule
{
    public bool CanExacute => _aiAgent.HasEnemy
                                && _aiAgent.CloseEnougthToAttack
                                && !_aiAgent.InAttackCoolDown;
                                
    private readonly AiAgent _aiAgent;

    public Attack(AiAgent aiAgent) =>
        _aiAgent = aiAgent;

    public void Execute()
    {
        _aiAgent.Shoot();
    }
}
