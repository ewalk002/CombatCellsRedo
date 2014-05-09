using UnityEngine;
using System.Collections;

public class ClickPlaneMenu : MonoBehaviour {

	public GUIStyle PriceStyle;
	public Texture wbcTexture;
	public Texture mucusTexture;
	public Texture syringeTexture;
	public Texture mortarTexture;
	public Texture teslaTexture;
	public bool valid;
	public bool CreateTurretMenu = false;
	public bool rayCast = false;
	
	private GameObject wbcTurret;
	private GameObject mucusTurret;
	private GameObject syringeTurret;
	private GameObject mortarTurret;
	private GameObject teslaTurret;
	private GameObject towerMenu;
	
	public bool AlreadyCreated = false;
	public bool gui = true;




	private GameObject lastHitObj = null;
	private GameObject menu = null;
	private Material originalMat;
	public Material hoverMat;


	// Use this for initialization
	void Start () {
		originalMat = gameObject.renderer.material;
		towerMenu = (GameObject)Resources.Load ( ConstantsLib.TOWER_MENU_PATH, typeof(GameObject));
		wbcTurret = (GameObject)Resources.Load ( ConstantsLib.WBC_PATH, typeof(GameObject));
		mucusTurret = (GameObject)Resources.Load ( ConstantsLib.MUCUS_PATH, typeof(GameObject));
		syringeTurret = (GameObject)Resources.Load ( ConstantsLib.SYRINGE_PATH, typeof(GameObject));
		mortarTurret = (GameObject)Resources.Load ( ConstantsLib.MORTAR_PATH, typeof(GameObject));
		teslaTurret = (GameObject)Resources.Load ( ConstantsLib.TESLA_PATH, typeof(GameObject));
	}
	  
	// Update is called once per frame
	void Update () {
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		var hit = new RaycastHit ();

		/*
		if( Physics.Raycast( ray, out hit ) )
		{
			print ( "true " + hit.point );
		}
		*/

		//print ( "Layer" + LayerMask.NameToLayer (ConstantsLib.RAY_CAST_LAYER_NAME));

		var rayCast = Physics.Raycast (ray, out hit, ConstantsLib.RAY_CAST_DIST, 
		                              LayerMask.NameToLayer (ConstantsLib.RAY_CAST_LAYER_NAME));

		print (rayCast.ToString());

		// cast to the tiles
		if( Physics.Raycast( ray, out hit, ConstantsLib.RAY_CAST_DIST, 
		                    LayerMask.NameToLayer( ConstantsLib.RAY_CAST_LAYER_NAME ) ) )
		{

			if( lastHitObj != null )
			{
				lastHitObj.renderer.material = originalMat;
			}

			lastHitObj = hit.collider.gameObject; // replace last objecct with what we just hit
			originalMat = lastHitObj.renderer.material; // store new planes atarting material
			lastHitObj.renderer.material = hoverMat; // set to hover material
		}
		else // did not hit anything. Set tiles to original material, and destroy menu
		{
			if( lastHitObj != null )
			{
				lastHitObj.renderer.material = originalMat;
				lastHitObj = null;
			}

			if( menu != null )
			{
				Destroy( menu );
				menu = null;
			}
		}

		// drop turrets on click
		if( Input.GetMouseButtonDown( 0 ) && lastHitObj != null ) // if LEFT mouse down, and object is selected
		{
			if( lastHitObj.tag == ConstantsLib.PLACEMENT_OPEN && menu != null )
			{
				Vector3 hitPoint = lastHitObj.transform.position; // position of object we hit
				hitPoint.y += ConstantsLib.Y_OFFSET; // raise it off the ground a bit

				menu = ( GameObject )Instantiate( towerMenu, hitPoint, Quaternion.identity );
			}
			//else if( lastHitObj.tag == ConstantsLib.
		}

	}
}














