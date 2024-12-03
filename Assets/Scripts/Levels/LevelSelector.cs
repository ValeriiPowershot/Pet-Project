using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Levels
{
    public class FancyLevelSelector : MonoBehaviour
    {
        [SerializeField] private List<Sprite> levelImages;
        [SerializeField] private Image displayImage;
        [SerializeField] private float animationDuration = 0.5f; 

        private int currentLevelIndex;

        private void Start() =>
            UpdateLevelDisplay();

        public void NextLevel()
        {
            if (currentLevelIndex >= levelImages.Count - 1) return;
            currentLevelIndex++;
            FlipAnimation();
        }

        public void PreviousLevel()
        {
            if (currentLevelIndex <= 0) return;
            currentLevelIndex--;
            FlipAnimation();
        }

        private void UpdateLevelDisplay()
        {
            displayImage.sprite = levelImages[currentLevelIndex];
        }

        private void FlipAnimation()
        {
            displayImage.transform.DOScaleY(0, animationDuration / 2).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                UpdateLevelDisplay();
                displayImage.transform.DOScaleY(1, animationDuration / 2).SetEase(Ease.InOutQuad);
            });
        }
    }
}
