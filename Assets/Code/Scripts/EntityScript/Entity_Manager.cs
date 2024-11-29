using UnityEngine;
using System.Collections.Generic;

using Entity_System.Entity;
using Entity_System.Entity.Enemy;
using Entity_System.Entity.Player;
using System.Linq;

namespace Entity_System
{
    public class Entity_Manager : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Player_View _playerView;
        [SerializeField] private Transform _playerSpawnTransform;
        [Space]
        [Header("Enemy")]
        [SerializeField] private Enemy_View _enemyView;
        [SerializeField] private int initialEnemyAmount = 15;

        private Player_Controller _playerController;
        private Player_Model _playerModel;

        private List<Enemy_Model> _enemyList;
        private ObjectPooler _enemyViewPooler;

        private void Awake()
        {
            //Instantiate Player View
            Player_View playerView = FindFirstObjectByType<Player_View>();
            if (playerView != null)
                _playerView = playerView;
            else
                _playerView = Instantiate(_playerView, transform);
            _playerView.transform.position = _playerSpawnTransform.position;
            //Initialize Player Model
            _playerModel = new Player_Model();
            _playerModel.Position = _playerSpawnTransform.position;
            //Initialize Player Controller
            _playerController = new Player_Controller(_playerModel, _playerView);

            //Initialize Enemy Views
            _enemyViewPooler = new ObjectPooler(_enemyView.gameObject, initialEnemyAmount, transform);

            //Recycle Enemy Views
            Enemy_View[] enemyViewer = FindObjectsByType<Enemy_View>(FindObjectsSortMode.None);
            for (int i = 0; i < enemyViewer.Length; i++)
                _enemyViewPooler.AddObject(enemyViewer[i].gameObject, transform, true);
        }

        private void OnEnable()
        {
            _playerController.Enable();
        }

        private void OnDisable()
        {
            _playerController.Disable();
        }

        private void FixedUpdate()
        {
            TickPlayer();
            TickEnemies();
        }

        private void TickPlayer()
        {
            _playerController.TickController();
        }

        private void TickEnemies()
        {

        }
    }
}
