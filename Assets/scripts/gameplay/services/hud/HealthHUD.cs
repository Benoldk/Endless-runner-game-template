using UnityEngine;
using System.Linq;

namespace game.package.gameplay
{
    public class HealthHUD : MonoBehaviour
    {
        [SerializeField] private RectTransform fullHeart;
        [SerializeField] private RectTransform emptyHeart;
        [SerializeField] private Vector2 StartPosition;

        private int curHP;

        public void SetHP(int value)
        {
            curHP = value;
            ClearHPUI();
            UpdateHPUI();
        }

        private void ClearHPUI()
        {
            var hpArr = transform.GetComponentsInChildren<RectTransform>()
                        .Where(r => r.transform != transform);
            foreach(var hp in hpArr)
            {
                Destroy(hp.gameObject);
            }
        }

        private void UpdateHPUI()
        {
            RectTransform prevRT = null;
            for (int i = 0; i < curHP; i++)
            {
                RectTransform rt = Instantiate(fullHeart);
                Vector2 pos = StartPosition;
                if (prevRT)
                    pos.x += prevRT.rect.width;
                rt.position = pos;
                rt.transform.parent = transform;
                prevRT = rt;
            }
        }
    }
}