using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour {
	
	private Transform Player;
	private Transform Camera;
	public float Distance;
	public float Speed = 0f;
	public float SmtS = 1f;
	private bool isDead = false;

	void Start ()
	{
		
		Player = GameObject.FindGameObjectWithTag("Player").transform;
		Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		}

	void Update ()
	{
		if (isDead)
		{
			Speed = 0f;
		}

		Vector3 camZ = new Vector3(Camera.transform.position.z,0);
        Vector3 plyZ = new Vector3(Player.transform.position.z,0);

        Vector3 position = this.transform.position;
		float Smooth = SmtS * Time.deltaTime;
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Speed * Time.deltaTime);
		Distance = Vector3.Distance (camZ,plyZ);

		if (Distance > 8) 
		{			
			position.z = Mathf.Lerp (Camera.transform.position.z,Player.transform.position.z - 3, Smooth);
			Camera.transform.position = position;
		} 
		else
		{
			Speed = Speed;
		}
	}
	public void onDead() 
	{
		isDead = true;
	}
}