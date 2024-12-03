using Cinemachine;
using Infrastructure;
using UnityEngine;

namespace Levels
{
    public class ScenePartCollider : MonoBehaviour
    {
        public CinemachineVirtualCamera Camera;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PlayerTag)) 
                SmoothCameraSwitcher.Instance.SetActiveCamera(Camera);
        }
    }
}
