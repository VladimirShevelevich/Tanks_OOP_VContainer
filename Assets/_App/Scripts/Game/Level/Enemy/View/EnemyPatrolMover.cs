using UnityEngine;
using VContainer;

namespace Game.Level.Enemy
{
    public class EnemyPatrolMover : MonoBehaviour
    {
        private Vector3? _targetPosition;

        private EnemyContent _enemyContent;

        [Inject]
        public void Construct(EnemyContent enemyContent)
        {
            _enemyContent = enemyContent;
        }

        public void Start()
        {
            var targetPos = transform.position + Vector3.right * _enemyContent.Movement.PatrolRange / 2;
            _targetPosition = targetPos;
        }

        private void OnDestinationReached()
        {
            var targetPos = (Vector3)_targetPosition;
            var newTargetPos = new Vector3(-targetPos.x, targetPos.y, targetPos.z);
            _targetPosition = newTargetPos;
        }       

        private void Update()
        {
            if (_targetPosition == null)
                return;

            Move();
        }
        
        private void Move()
        {
            var targetPosition = (Vector3)_targetPosition;
            transform.LookAt(targetPosition);
            
            var step = _enemyContent.Movement.Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            Vector3.MoveTowards(transform.position, targetPosition, step);
            
            if (transform.position == targetPosition)
                OnDestinationReached();
        }
    }
}