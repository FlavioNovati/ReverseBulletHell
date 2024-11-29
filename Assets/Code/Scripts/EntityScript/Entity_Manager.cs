using UnityEngine;
using System.Collections.Generic;

using Entity_System.Entity.Enemy;
using Entity_System.Entity.Player;

namespace Entity_System
{
    public class Entity_Manager : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Player_SO _playerSO;
        [SerializeField] private Transform _playerSpawnTransform;
        [Space]
        [Header("Enemy")]
        [SerializeField] private Enemy_SO _enemySO;
        [SerializeField] private int initialEnemyAmount = 15;

        private Player_Controller _playerController;
        private Player_Model _playerModel;

        private List<Enemy_Model> _enemyList;
        private List<Enemy_View> _enemyViewList;
        private List<Enemy_Controller> _activeControllers;

        private ObjectPooler _enemyViewPooler;

        private void Awake()
        {
            //Instantiate Player View
            Player_View playerView = Instantiate(_playerSO.View, transform);
            playerView.transform.position = _playerSpawnTransform.position;
            //Initialize Player Model
            _playerModel = new Player_Model(_playerSO);
            _playerModel.Position = _playerSpawnTransform.position;
            //Initialize Player Controller
            _playerController = new Player_Controller(_playerModel, playerView);


            //Initialize Enemies
            //Model
            _enemyList = new List<Enemy_Model>();
            for (int i = 0; i < initialEnemyAmount; i++)
                _enemyList.Add(new Enemy_Model(_enemySO));
            //View
            _enemyViewPooler = new ObjectPooler(_enemySO.View.gameObject, initialEnemyAmount, transform);
            _enemyViewList = new List<Enemy_View>();
            for(int i = 0; i < initialEnemyAmount; i++)
            {
                _enemyViewList.Add(_enemyViewPooler.PoolObject().GetComponent<Enemy_View>());
                _enemyViewList[^1].gameObject.SetActive(true);
            }
            //Controller
            _activeControllers = new List<Enemy_Controller>();
            for (int i = 0; i < initialEnemyAmount; i++)
                _activeControllers.Add(new Enemy_Controller(_enemyList[i], _enemyViewList[i]));
        }

        private void Start()
        {
            
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

        private void TickPlayer() => _playerController.TickController();

        private void TickEnemies()
        {
            for(int i=0; i < _activeControllers.Count; i++)
                TickEnemy(_activeControllers[i]);
        }

        private void TickEnemy(Enemy_Controller enemyController)
        {
            //Update rotation
            Enemy_Model model = enemyController.Model;
            model.Direction = model.Position - _playerModel.Position;

            //Update Distance
            model.DistanceFromTarget = model.Direction.magnitude;

            enemyController.TickController();
        }
    }
}
