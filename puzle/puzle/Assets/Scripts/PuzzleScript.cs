using UnityEngine;
using UnityEngine.UI;

public class PuzzleScript : MonoBehaviour
{
    private bool _isFollowingMouse = false;
    private bool _isPlaced = false;
    public GameObject _puzzleObject;
    public GameObject _finalPosition;
    public AudioSource _soundEffect;
    public Text _winText;
    private bool _isPuzzleAttached = false;
    private int _totalPuzzles = 36; // Общее количество пазлов
    private static int _placedPuzzles = 0; // Количество уже закрепленных пазлов
    private static int _followers = 1;
    private int _correctFollower = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isPlaced)
        {
            if (_followers == _correctFollower)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject == _puzzleObject)
                {
                    if (!_isFollowingMouse)
                    {
                        _followers = 1;
                        _isFollowingMouse = true;
                        _isPuzzleAttached = true; // Устанавливаем флаг, что пазл прикреплен
                    }
                }
            }
        }


        if (_isFollowingMouse && Input.GetMouseButton(0) && !_isPlaced)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _puzzleObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }

        if (Input.GetMouseButtonUp(0) && _isFollowingMouse)
        {
            _followers = 0;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_puzzleObject.transform.position, 0.1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == _finalPosition)
                {
                    _followers = 1;
                    _isFollowingMouse = false;
                    _puzzleObject.transform.position = _finalPosition.transform.position;
                    _isPlaced = true;
                    //_isPuzzleAttached = false;
                    if (_soundEffect != null)
                    {
                        _soundEffect.Play();
                    }

                    _placedPuzzles += 1; // Увеличиваем количество закрепленных пазлов
                    Debug.Log(_placedPuzzles);

                    if (_placedPuzzles == _totalPuzzles) // Проверяем, если все пазлы закреплены
                    {
                        if (_soundEffect != null)
                        {
                            _soundEffect.Play();
                        }

                        _winText.text = "You Win! :)"; // Устанавливаем текст "You Win! :)"
                    }

                    break;
                }
            }
        }
    }
}