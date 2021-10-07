using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace game.package.menus
{
    [CustomEditor(typeof(SimpleCreditsMenu))]
    [CanEditMultipleObjects]
    public class SectionedCreditsMenuEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            //SectionedCreditsMenu creditsMenu = (SectionedCreditsMenu)target;

            //creditsMenu.creditsContainer = (GameObject)EditorGUILayout.ObjectField("Credits Container", creditsMenu.creditsContainer, typeof(GameObject), true);
            ////creditsMenu.gameCreditPrefab = (CreditSection)EditorGUILayout.ObjectField("Game Credit Prefab", creditsMenu.gameCreditPrefab, typeof(CreditSection), true);
            //creditsMenu.textPrefab = (TextMeshProUGUI)EditorGUILayout.ObjectField("Text Prefab", creditsMenu.textPrefab, typeof(TextMeshProUGUI), true);

            //creditsMenu.displayOptions = EditorGUILayout.Foldout(creditsMenu.displayOptions, "Credits List", true);
            //if (creditsMenu.displayOptions)
            //{
            //    EditorGUI.indentLevel++;

            //    List<CreditSection> creditsOptions = creditsMenu.creditOptions;
            //    int size = Mathf.Max(0, EditorGUILayout.IntField("Size", creditsOptions.Count));

            //    while(size > creditsOptions.Count)
            //    {
            //        //var prefab = Instantiate(creditsMenu.gameCreditPrefab);
            //        prefab.gameObject.SetActive(true);
            //        creditsOptions.Add(prefab);
            //        prefab.transform.SetParent(creditsMenu.creditsContainer.transform);
            //    }

            //    while (size < creditsOptions.Count)
            //    {
            //        creditsOptions.RemoveAt(creditsOptions.Count-1);
            //    }

            //    for (int i = 0; i < creditsOptions.Count; i++)
            //    {
            //        EditorGUILayout.BeginVertical();
            //        EditorGUILayout.LabelField("Credit");
            //        EditorGUI.indentLevel++;

            //        creditsOptions[i].title = EditorGUILayout.TextField("Title", creditsOptions[i].title);
            //        //creditsOptions[i].description = EditorGUILayout.TextField("Description", creditsOptions[i].description);

            //        EditorGUI.indentLevel--;
            //        EditorGUILayout.EndVertical();
            //    }

            //    EditorGUI.indentLevel--;
            //}
        }
    }
}