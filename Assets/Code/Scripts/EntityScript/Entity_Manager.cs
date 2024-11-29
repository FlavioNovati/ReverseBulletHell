using UnityEngine;
using System.Collections.Generic;

public class Entity_Manager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Entity_View _playerView;
    [Space]
    [Header("Enemy")]
    [SerializeField] private Entity_View _enemyView;
    [SerializeField] private int initialEnemyAmount = 15;

    private Player_Model _playerModel;

    private List<Enemy_Model> _enemyList;
    private ObjectPooler _enemyViewPooler;

    private void Awake()
    {
        //Instantiate Player View
        _playerView = Instantiate(_playerView, transform);
        //Initialize Enemy Views
        _enemyViewPooler = new ObjectPooler(_enemyView.gameObject, initialEnemyAmount, transform);
    }

    private void FixedUpdate()
    {
        UpdatePlayer();
        UpdateEnemies();
    }

    private void UpdatePlayer()
    {

    }

    private void UpdateEnemies()
    {

    }

}
