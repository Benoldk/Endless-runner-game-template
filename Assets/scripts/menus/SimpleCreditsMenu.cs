using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace game.package.menus
{
    public class SimpleCreditsMenu : MonoBehaviour
    {
        public GameObject creditsContainer;
        public TextMeshProUGUI textPrefab;
        public Vector2 startPosition;
        public Vector2 endPosition;
        public Vector3 velocity;
        public List<string> creditOptions;

        private void OnEnable()
        {
            creditsContainer.GetComponent<RectTransform>().localPosition = startPosition;
            foreach (var option in creditOptions)
            {
                CreateCreditOption(option);
            }
        }

        private void OnDisable()
        {
            foreach(RectTransform child in GetComponentInChildren<RectTransform>())
            {
                if(child != GetComponent<RectTransform>())
                {
                    Destroy(child.gameObject);
                }
            }
        }

        private void CreateCreditOption(string optionText)
        {
            var option = Instantiate(textPrefab);
            option.GetComponent<RectTransform>().SetParent(null);
            option.GetComponent<RectTransform>().SetParent(creditsContainer.transform);
            option.GetComponent<RectTransform>().localScale = Vector3.one;
            option.text = optionText;
            option.gameObject.SetActive(true);
        }

        private void Update()
        {
            if(Vector3.Distance(endPosition, creditsContainer.transform.localPosition) > 0.5f)
                creditsContainer.transform.localPosition += velocity * Time.deltaTime;
        }
    }
}