using UnityEngine;

public class TriggerModifyScore : MonoBehaviour
{
    public void ModifyScore(int score)
    {
        GameManager.Singleton.ModifyScore(score);
    }
}
