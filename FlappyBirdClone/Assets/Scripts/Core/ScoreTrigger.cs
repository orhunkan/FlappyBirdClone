using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Bird"))
        {
            GameManager.Instance.AddScore();
        }
    }
}
