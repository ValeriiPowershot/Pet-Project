using Cinemachine;
using UnityEngine;

namespace Levels
{
    public class SmoothCameraSwitcher : MonoBehaviour
    {
        public static SmoothCameraSwitcher Instance;
    
        public CinemachineVirtualCamera[] AllCameras;
        private int currentCameraIndex;

        private void Awake() =>
            Instance = this;

        private void Start()
        {
            if (AllCameras.Length > 0)
                SetActiveCamera(AllCameras[0]);
            else
                Debug.LogWarning("No cameras set in the array.");
        }
    
        public void SetActiveCamera(CinemachineVirtualCamera virtualCamera)
        {
            foreach (CinemachineVirtualCamera cam in AllCameras) 
                cam.Priority = 0;
        
            virtualCamera.Priority = 10;
        }
    }
}
