using System;
using UnityEngine;
using DG.Tweening;
using Zenject;

namespace Logic
{
    public class Player : MonoBehaviour
    {
        public Action IsDead;
        
        private WayPoints _wayPoints;
        private int _currentPointID;
        private bool _canMove = true;

        [Inject]
        public void Construct(WayPoints wayPoints)
        {
            _wayPoints = wayPoints;
        }

        public void Move()
        {
            if (!_canMove) return;
            
            MoveToNextPoint(gameObject.transform, new Vector3(
                _wayPoints.WayPointTransforms[_currentPointID].transform.position.x,
                _wayPoints.WayPointTransforms[_currentPointID].transform.position.y,
                _wayPoints.WayPointTransforms[_currentPointID].transform.position.z) );

            _currentPointID++;
        }

        public void Die()
        {
            IsDead?.Invoke();
            Debug.Log("DIE");
        }
        
        private void MoveToNextPoint(Transform objectToMove, Vector3 at)
        {
            _canMove = false;
            objectToMove.DOMove(at, 1).OnComplete(() => _canMove = true);
        }
    }
}
