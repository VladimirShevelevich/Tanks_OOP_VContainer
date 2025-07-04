using UnityEngine;

namespace Game.Level.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private bool _isPatrolMovementOn;
        private EnemyContent.MovementContent _movementContent;
        private Vector3 _targetPosition;

        public void ExecutePatrolMovement(EnemyContent.MovementContent enemyContentMovement)
        {
            _movementContent = enemyContentMovement;
            
            _isPatrolMovementOn = true;
            _targetPosition = transform.position + Vector3.right * _movementContent.PatrolRange / 2;
        }

        private void Update()
        {
            if (!_isPatrolMovementOn)
                return;

            Move();
        }

        private void Move()
        {
            transform.LookAt(_targetPosition);
            
            var step = _movementContent.Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
            Vector3.MoveTowards(transform.position, _targetPosition, step);
            
            if (transform.position == _targetPosition)
                OnDestinationReached();
        }

        private void OnDestinationReached()
        {
            _targetPosition = new Vector3(-_targetPosition.x, _targetPosition.y, _targetPosition.z);
        }
    }
}