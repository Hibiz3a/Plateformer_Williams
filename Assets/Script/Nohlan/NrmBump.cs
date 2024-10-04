using UnityEngine;

public class NrmBump : MonoBehaviour {
    [SerializeField] GameObject Player;
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == Player) {
            collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, 7);
            transform.GetComponent<ParticleSystem>().Play();
        }
    }
}
