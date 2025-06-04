using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isDead = false;

    public AudioClip wingClip, hitClip;

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
            rb.velocity = Vector2.up * jumpForce;
            AudioSource.PlayClipAtPoint(wingClip, Camera.main.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        isDead = true;
        AudioSource.PlayClipAtPoint(hitClip, Camera.main.transform.position);
        GameManager.Instance.GameOver();
    }
}
