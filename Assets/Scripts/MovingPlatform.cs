using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Transform platform;

    [SerializeField]
    Transform startTransform;

    [SerializeField]
    Transform endTransform;

    [SerializeField]
    float platformSpeed = 2;

    Rigidbody platformRb;
    Vector3 direction;
    Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        platformRb = platform.GetComponent<Rigidbody>();
        setDestination(startTransform);
    }

    // Physics adjustments should be done in fixedupdate
    // fixedupdate has a fixed time step rather than being tied to frame rate
    void FixedUpdate()
    {
        platformRb.MovePosition(platform.position + direction * platformSpeed * Time.fixedDeltaTime);

        float distance = Vector3.Distance(platform.position, destination.position);
        if (distance < platformSpeed * Time.fixedDeltaTime)
        {
            setDestination((destination == startTransform) ? endTransform : startTransform);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(startTransform.position, platform.localScale);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endTransform.position, platform.localScale);
    }

    void setDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - platform.position).normalized;
    }
}
