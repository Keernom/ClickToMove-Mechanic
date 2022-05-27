using UnityEngine;
using UnityEngine.AI;

namespace ClickToMove
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed = 1f;

        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (InteractWithMovement()) { return; }
            Debug.Log("There is no way");
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool rayCastHit = Physics.Raycast(GetMouseRay(), out hit);

            if (rayCastHit)
            {
                if (Input.GetMouseButton(0))
                {
                    MoveTo(hit.point);
                }
                return true;
            }
            return false;
        }

        public void MoveTo(Vector3 destination)
        {
            _navMeshAgent.destination = destination;
            _navMeshAgent.speed = _maxSpeed;
            _navMeshAgent.isStopped = false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

