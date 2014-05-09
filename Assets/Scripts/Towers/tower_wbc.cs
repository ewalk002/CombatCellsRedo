using UnityEngine;
using System.Collections;

public class tower_wbc : MonoBehaviour {

	public GameObject projectilePrefab = null;
	public float reloadTime = ConstantsLib.WBC_RELOAD_TIME;
	public float turnSpeed = ConstantsLib.WBC_TURN_SPEED;
	public int cost = ConstantsLib.WBC_COST;
	//public GameObject muzzleEffect = null;
	public Transform target = null;
	public Transform muzzlePosition = null;
	public Transform tower = null;

	private float nextFireTime;
	private float nextMoveTime;
	private Quaternion desiredRotation;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if( target != null )
		{
			CalculateAimPosition( target.position );
			tower.rotation = Quaternion.Lerp( tower.rotation, 
			                                      desiredRotation, 
			                                      Time.deltaTime * turnSpeed );

			if( Time.time >= nextFireTime )
			{
				FireProjectile();
			}
		}


	}

	void OnTriggerEnter( Collider other )
	{
		if (other.gameObject.tag == "Enemy")
		{
			target = other.gameObject.transform;
		}
	}

	void OnTriggerExit( Collider other )
	{
		if( other.gameObject.transform == target )
		{
			target = null;
		}
	}

	void CalculateAimPosition( Vector3 targetPos )
	{
		Vector3 aimPoint = new Vector3 (targetPos.x, targetPos.y, targetPos.z);
		desiredRotation = Quaternion.LookRotation (aimPoint - transform.position);
	}

	void FireProjectile()
	{
		audio.Play ();
		nextFireTime = Time.time + reloadTime;
		Instantiate (projectilePrefab, muzzlePosition.position, muzzlePosition.rotation);
		//Instantiate (muzzleEffect, muzzlePosition.position, muzzlePosition.rotation);
	}
}
