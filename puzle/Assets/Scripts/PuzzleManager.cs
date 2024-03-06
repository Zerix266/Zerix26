using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private Transform[] puzzlePieces;

    private int selectedPieceIndex = -1;
    private Vector3 offset;

    void Start()
    {
        // Находим все объекты с тегом "puzzle" в сцене
        GameObject[] puzzleObjects = GameObject.FindGameObjectsWithTag("Puzzle");

        // Изменяем позицию каждого объекта на (x, y)
        foreach (GameObject puzzleObject in puzzleObjects)
        {
            puzzleObject.transform.position = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-4f, 4f);
        float y = Random.Range(-10f, -18f);
        return new Vector3(x, y, 0);
    }
}
