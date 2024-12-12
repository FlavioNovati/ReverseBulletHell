using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

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
        [SerializeField] private float _spawnRadius = 15f;
        [SerializeField] private Color _spawnAreaColor = Color.white;
        [SerializeField] private float _maxRadius = 40f;
        [SerializeField] private Color _maxRadiusColor = Color.red;
        [SerializeField] private int initialEnemyAmount = 15;

        private Player_Controller _playerController;
        private Player_Model _playerModel;

        private List<Enemy_Model> _enemyList;
        private List<Enemy_View> _enemyViewList;
        private List<Enemy_Controller> _activeControllers;

        private ObjectPooler _enemyViewPooler;

        private Camera _cameraRef;

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
            {
                _enemyList.Add(new Enemy_Model(_enemySO));
                _enemyList[^1].Position = GetRandomPosition();
            }
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
            CameraBounds.UpdateCameraBounds();
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
            model.TargetPos = _playerModel.Position;

            //Update Distance
            model.DistanceFromTarget = model.TargetPos.magnitude;

            //Check if enemy is in View
            model.InView = CameraBounds.VectorInBounds(model.Position);

            if(model.DistanceFromTarget >= _maxRadius)
            {
                enemyController.Disable();
                _activeControllers.Remove(enemyController);
                return;
            }

            if(model.DistanceFromTarget <= model.AttackDistance)
                _playerModel.Damage(model.AttackDamage);

            enemyController.TickController();
        }

        private Vector2 GetRandomPosition()
        {
            Vector2 spawnPos = Random.insideUnitCircle.normalized * _spawnRadius;
            spawnPos += _playerModel.Position;
            return spawnPos;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {

            if(!Application.isPlaying)
            {
                Handles.color = _spawnAreaColor;
                Handles.DrawWireDisc(transform.position, Vector3.forward, _spawnRadius);
                Handles.color = _maxRadiusColor;
                Handles.DrawWireDisc(transform.position, Vector3.forward, _maxRadius);
            }
            else
            {
                if(_playerModel != null)
                {
                    Handles.color = _spawnAreaColor;
                    Handles.DrawWireDisc(_playerModel.Position, Vector3.forward, _spawnRadius);
                    Handles.color = _maxRadiusColor;
                    Handles.DrawWireDisc(_playerModel.Position, Vector3.forward, _maxRadius);
                }

                foreach(Enemy_Controller controller in _activeControllers)
                {
                    Handles.color = controller.Model.InView? Color.green: new Color(0f, 1f, 0f, 0.25f);
                    Handles.DrawWireDisc(controller.Position, Vector3.forward, controller.Model.AttackDistance);
                }
            }
        }
#endif

    }
}
