using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private List<GameObject> _cans; // Lista de elementos de objetivos
    private int _score = 0;

    public TextMeshProUGUI scoreText; // Referencia al componente TextMeshProUGUI para mostrar la puntuación
    void Start()
    {
        _cans = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cans"));
    }
    public void TargetHit(GameObject go)
    {
        scoreText.text = "Score: " + _score;
        Debug.Log("Score: " + _score);
        if (_cans.Contains(go))
        {
            _score += 10;
            _cans.Remove(go);
            Debug.Log("Score " + _score);
            Destroy(go, 5);
        }
    }
}
