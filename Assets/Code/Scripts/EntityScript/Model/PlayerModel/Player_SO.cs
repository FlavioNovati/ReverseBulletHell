using UnityEngine;

namespace Entity_System.Entity.Player
{
    [CreateAssetMenu(fileName = "New Player", menuName = "scriptable/Entity/Player")]
    public class Player_SO : Entity_SO
    {
        [Header("Player")]
        [SerializeField] private Player_View _player_View;

        public Player_View View => _player_View;
    }
}
