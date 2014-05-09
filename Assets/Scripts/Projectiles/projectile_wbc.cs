using UnityEngine;
using System.Collections;

public class projectile_wbc : MonoBehaviour {

	public float speed = ConstantsLib.WBC_PROJ_SPEED;
	public float range = ConstantsLib.WBC_PROJ_RANGE;

	private float currentDist = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed );
		currentDist += Time.deltaTime * speed;

		if( currentDist >= range )
		{
			Destroy( gameObject );
		}
	}
}
