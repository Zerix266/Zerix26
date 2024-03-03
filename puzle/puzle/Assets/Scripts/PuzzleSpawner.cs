using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSpawner : MonoBehaviour
{
    public GameObject puzzlePrefab; // Префаб пазла
    public Transform contentPanel; // Панель, к которой будут добавляться пазлы
    public int numberOfPuzzles = 36; // Количество пазлов

    void Start()
    {
        for (int i = 0; i < numberOfPuzzles; i++)
        {
            GameObject newPuzzle = Instantiate(puzzlePrefab, contentPanel);
            // Добавляем пазл в scrollbar
        }
    }
}
