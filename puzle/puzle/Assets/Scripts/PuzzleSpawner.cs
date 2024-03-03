using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSpawner : MonoBehaviour
{
    public GameObject puzzlePrefab; // ������ �����
    public Transform contentPanel; // ������, � ������� ����� ����������� �����
    public int numberOfPuzzles = 36; // ���������� ������

    void Start()
    {
        for (int i = 0; i < numberOfPuzzles; i++)
        {
            GameObject newPuzzle = Instantiate(puzzlePrefab, contentPanel);
            // ��������� ���� � scrollbar
        }
    }
}
