using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isDead = false;

    [SerializeField]
    private AudioSource _source;

    public AudioClip wingClip, hitClip;

    public float tiltSmooth = 5f;       
    public float maxRotation = 30f;     
    public float minRotation = -90f;   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (isDead) return;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
#endif
        {
            rb.velocity = Vector3.up * jumpForce;
            _source.PlayOneShot(wingClip);
        }

        RotateBird();
    }

    private void RotateBird()
    {
        float angle = Mathf.Clamp(rb.velocity.y * 5f, minRotation, maxRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), tiltSmooth * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe") || other.CompareTag("Base"))
        {
            if (isDead) return;
            isDead = true;
            _source.PlayOneShot(hitClip);
            GameManager.Instance.GameOver();
        }
    }
}
