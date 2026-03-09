using UnityEngine;

public class Paddle : MonoBehaviour
{
	protected Rigidbody2D _rb2d;
	private SpriteRenderer _spriteRenderer;
	private AudioSource _audioSource;
	public float speed;

	private void Awake()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball>();

		if (ball != null) {
			
			float halfHeight = _spriteRenderer.bounds.size.y / 2;

			float coly = collision.transform.position.y;
			float recty = this.transform.position.y;
			float ratio = (recty - coly) / halfHeight;


			Vector2 normal = collision.GetContact(0).normal * -1;
			Vector2 vel = ball._rb2d.velocity;

			_audioSource.time = 0.26f;
			_audioSource.Play();

			if (normal.x == 1) {
				/* Player 1 */
				normal = Quaternion.AngleAxis(90 * ratio * -1, Vector3.forward) * normal;

			} else if (normal.x == -1) {
				/* Player 2 */
				normal = Quaternion.AngleAxis(90 * ratio, Vector3.forward) * normal;
			} else {
				return;
			}

			normal.x = vel.x;
			normal.y = normal.y * 4;
			ball._rb2d.velocity = normal;

			
		}
	}

	public void ResetPosition()
	{
		Vector2 position = _rb2d.position;
		position.y = 0;
		_rb2d.position = position;
		_rb2d.velocity = Vector2.zero;
	}
}