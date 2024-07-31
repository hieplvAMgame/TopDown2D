using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public int GetTotalEnemies() => enemies.Count;
    [SerializeField] float minX, maxX, minY, maxY;
    public void SetCameraBound(ref CameraFollower follower)
    {
        follower.SetBound(minX, maxX, minY, maxY);
    }
}
[CreateAssetMenu(fileName = "New Level Data", menuName = "Create Level Data")]
public class LevelData : ScriptableObject
{
    public int totalEnemy;
    public int timePlay;
}
