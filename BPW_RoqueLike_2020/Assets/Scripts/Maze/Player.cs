using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	private MazeCell currentCell;
	public GameManager gm;

	Vector3 _CharacterDirection, realativedir;
	Quaternion _CharacterRotation, rot;
	public CharacterController _CharacterRigidbody;
	Vector3 velocity;
	public float gravity = -9.81f;
	[SerializeField]
	float TurnSpeed = 8, speed = 6;
	bool _IsWalking;
	[SerializeField]
	Camera VCam;
	public GameObject maincam;
	public Vector3 t22;
	public Animator ani;
	public Inventory t;
	public GameObject portaltip;

	public void SetLocation (MazeCell cell) {
		if (currentCell != null) {
			currentCell.OnPlayerExited();
		}
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
		currentCell.OnPlayerEntered();
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
	private void Start()
	{
		portaltip.gameObject.SetActive(false);
		maincam = GameObject.Find("MainCamera");
		maincam.SetActive(false);
	}

	void FixedUpdate()
	{
		if (!GameManager.gamepauze)
		{
			CharacterMovement();
		}
	}
	private void OnTriggerExit(Collider other)
	{
		portaltip.gameObject.SetActive(false);
	}
	private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name == "PortalSpawn")
		{
			if (GameObject.FindGameObjectsWithTag("enemy").Length <= 0)
			{
				portaltip.gameObject.SetActive(false);
				GameManager.enemiesCounter = GameManager.enemiesCounter + 5;
				GameManager.level = GameManager.level + 1;
				if (GameManager.level == 4)
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					SceneManager.LoadScene("WinMenu");
				}
				else
				{
					SceneManager.LoadScene("Game");
				}
			}
			else { portaltip.gameObject.SetActive(true); }
		}

		if (other.name == "Coin")
		{
			ani.Play("inven");
			GetComponent<AudioSource>().Play();
			other.transform.parent.gameObject.SetActive(false);
			t.GiveItem(other.gameObject.transform.parent.GetComponent<CoinScript>().indexitem);
		}
	}

	void CharacterMovement()
	{

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;
		t22 = transform.right * x + transform.forward * z;
		_CharacterRigidbody.Move(move * speed * Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;
		_CharacterRigidbody.Move(velocity * Time.deltaTime);
	}
}