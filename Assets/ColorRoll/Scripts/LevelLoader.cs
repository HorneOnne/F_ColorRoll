using UnityEngine;

namespace ColorRoll
{
    public class LevelLoader : MonoBehaviour
    {
        private LevelData _levelData;
        private void Start()
        {
            _levelData = GameManager.Instance.PlayingLevelData;
            Instantiate(_levelData.LevelPrefab);
            GameplayManager.Instance.ChangeGameState(GameplayManager.GameState.PLAYING);
        }
    }
}
