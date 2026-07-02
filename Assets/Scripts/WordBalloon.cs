using UnityEngine;

public class WordBalloon : MonoBehaviour
{
    [SerializeField] float offsetY = 4.4f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Update()
    {
        if (transform.parent != null)
        {
            // 부모의 위치만 따라감
            initialPosition = transform.parent.position;
            initialPosition.y += offsetY;
            
            transform.SetPositionAndRotation(initialPosition, Quaternion.identity);
        }

    }
}
