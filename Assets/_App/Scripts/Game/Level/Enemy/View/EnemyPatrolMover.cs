using System;
using UniRx;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

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
            SetInitialTargetPosition();
        }

        private void SetInitialTargetPosition()
        {
            var randomRange = Random.Range(
                _enemyContent.Movement.PatrolRange.x,
                _enemyContent.Movement.PatrolRange.y);
            
            var targetPos = new Vector3(
                randomRange / 2,
                transform.position.y,
                transform.position.z) ;
            _targetPosition = targetPos;
        }

        private void OnDestinationReached()
        {
            var targetPos = (Vector3)_targetPosition;

            Observable.Timer(TimeSpan.FromSeconds(_enemyContent.Movement.PatrolWaitTime)).Subscribe(_ =>
            {
                SetNewTargetPosition(targetPos);
            }).AddTo(this);
        }

        private void SetNewTargetPosition(Vector3 targetPos)
        {
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