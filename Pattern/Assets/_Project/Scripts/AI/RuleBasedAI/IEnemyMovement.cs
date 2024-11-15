using UnityEngine;

public interface IEnemyMovement
{
    void MoveTo(Vector3 enemyPosition);

    void MoveAway(Vector3 enemyPostion);
}
