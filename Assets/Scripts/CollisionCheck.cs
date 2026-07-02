using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    Rocket rocket;

    private void Start()
    {
        rocket = GetComponent<Rocket>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Obstacle":
                rocket.enabled = false;
                Invoke("ResetLevel", 2.0f);
                break;
            case "Finish":
                Invoke("NextLevel", 2.0f);
                break;
        }
    }

    void ResetLevel()
    {
        rocket.enabled = true;
        GameManager.Instance.ResetLevel();
    }

    void NextLevel()
    {
        rocket.enabled = true;
        GameManager.Instance.LoadNextLevel();
    }
}
