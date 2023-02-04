using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartScreen : MonoBehaviour
{
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonStart = root.Q<Button>("startButton");

        // buttonStart.clicked += () => 
    }
}
