public interface IRule
{
    bool CanExacute { get; }

    void Execute();
}
