using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	private GameObject wbcTurret;
	private GameObject mucusTurret;
	private GameObject syringeTurret;
	private GameObject mortarTurret;
	private GameObject teslaTurret;
	private GameObject towerMenu;

	private GameObject lastHoverObj = null;
	private GameObject currHoverObj = null;

	private GameObject lastMenuedObj = null;
	private GameObject currMenuedObj = null;

	private GameObject menu = null;
	private GameObject menuTowerIcon = null;

	//towers
	private GameObject wbc = null;

	public bool hoverMade;
	public bool menuMade;

	public Material originalMat;
	public Material hoverMat;
	public Material menuedMat;

	private int placementLayerMask;
	private int wbcLayerMask;
	private int mucusLayerMask;
	private int mortarLayerMask;
	private int syringLayerMask;
	private int teslaLayerMask;
	private int towerMenuLayerMask;


	// Use this for initialization
	void Start () {
		menuMade = false;
		hoverMade = false;

		// Layer masks
		wbcLayerMask = 1 << (LayerMask.NameToLayer (ConstantsLib.RAY_CAST_WBC));
		mucusLayerMask = 1 << (LayerMask.NameToLayer (ConstantsLib.RAY_CAST_MUCUS));
		mortarLayerMask = 1 << (LayerMask.NameToLayer (ConstantsLib.RAY_CAST_MORTAR));
		syringLayerMask = 1 << (LayerMask.NameToLayer (ConstantsLib.RAY_CAST_SYRINGE));
		teslaLayerMask = 1 << (LayerMask.NameToLayer (ConstantsLib.RAY_CAST_TESLA));
		placementLayerMask = 1 << (LayerMask.NameToLayer (ConstantsLib.RAY_CAST_TILES));
		towerMenuLayerMask = wbcLayerMask | mucusLayerMask | mortarLayerMask | 
			syringLayerMask | teslaLayerMask;

		//originalMat = gameObject.renderer.material;
		towerMenu = (GameObject)Resources.Load ( ConstantsLib.TOWER_MENU_PATH, typeof(GameObject));
		wbcTurret = (GameObject)Resources.Load ( ConstantsLib.WBC_PATH, typeof(GameObject));
		mucusTurret = (GameObject)Resources.Load ( ConstantsLib.MUCUS_PATH, typeof(GameObject));
		syringeTurret = (GameObject)Resources.Load ( ConstantsLib.SYRINGE_PATH, typeof(GameObject));
		mortarTurret = (GameObject)Resources.Load ( ConstantsLib.MORTAR_PATH, typeof(GameObject));
		teslaTurret = (GameObject)Resources.Load ( ConstantsLib.TESLA_PATH, typeof(GameObject));
	}

	void newMenu( GameObject tile ) // makes new menu facing camera, sets menuMad  to true
	{
		tile.renderer.material = menuedMat; // set clicked tile to green color
		Vector3 hitPoint = tile.transform.position; // position of object we hit
		hitPoint.y += ConstantsLib.Y_OFFSET; // raise it off the ground a bit
		Vector3 atCamera = Camera.main.transform.position - tile.transform.position;
		menu = ( GameObject )Instantiate( towerMenu, hitPoint, 
		                                 Quaternion.LookRotation( atCamera ) );
		menuMade = true;
	}

	void deleteMenu( GameObject m, GameObject tile ) // destroys menu and sets menuMade to false
	{
		Destroy( m );
		tile.renderer.material = originalMat;
		menuMade = false;
	}

	// Update is called once per frame
	void Update () {

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		var hit = new RaycastHit ();

		if( Physics.Raycast( ray, out hit, Mathf.Infinity, towerMenuLayerMask ) )
		{
			if( Input.GetMouseButtonDown( 0 ) )
			{
				//Debug.Log ( "Hit the menu" );
				
				menuTowerIcon = hit.collider.gameObject; // replace last objecct with what we just hit
				Vector3 hitPoint = currMenuedObj.transform.position;
				//hitPoint.y += ConstantsLib.Y_OFFSET;
				
				deleteMenu( menu, currMenuedObj );
				
				if( menuTowerIcon.tag == ConstantsLib.WBC_ICON_TAG )
				{
					wbc = (GameObject)Instantiate( wbcTurret, hitPoint, 
					                              Quaternion.identity );
				}
				else if( menuTowerIcon.tag == ConstantsLib.MUCUS_ICON_TAG )
				{
					wbc = (GameObject)Instantiate( mucusTurret, hitPoint, 
					                              Quaternion.identity );
				}
				else if( menuTowerIcon.tag == ConstantsLib.MORTAR_ICON_TAG )
				{
					wbc = (GameObject)Instantiate( mortarTurret, hitPoint, 
					                              Quaternion.identity );
				}
				else if( menuTowerIcon.tag == ConstantsLib.SYRINGE_ICON_TAG )
				{
					wbc = (GameObject)Instantiate( syringeTurret, hitPoint, 
					                              Quaternion.identity );
				}
				else if( menuTowerIcon.tag == ConstantsLib.TESLAS_ICON_TAG )
				{
					wbc = (GameObject)Instantiate( teslaTurret, hitPoint, 
					                              Quaternion.identity );
				}
			}
		}
		else if( Physics.Raycast( ray, out hit, Mathf.Infinity, placementLayerMask ) )
		{
			currHoverObj = hit.collider.gameObject;
			if( !hoverMade )
			{
				currHoverObj.renderer.material = hoverMat;
				lastHoverObj = currHoverObj;
				hoverMade = true;
			}
			else if( hoverMade && ( currHoverObj != lastHoverObj ) )
			{
				lastHoverObj.renderer.material = originalMat;
				currHoverObj.renderer.material = hoverMat;
				lastHoverObj = currHoverObj;
			}


			if( Input.GetMouseButtonDown( 0 ) )
			{		 
				currMenuedObj = hit.collider.gameObject;
				if( !menuMade )
				{
					//Debug.Log( "a" );
					newMenu( currMenuedObj );
					lastMenuedObj = currMenuedObj;
				}

				else if( menuMade && ( currMenuedObj == lastMenuedObj ) )
				{
					//Debug.Log( "b" );
					deleteMenu( menu, lastMenuedObj );
					currMenuedObj = null;
				}

				else if( menuMade && ( currMenuedObj != lastMenuedObj ) )
				{
					//Debug.Log( "c" );
					deleteMenu( menu, lastMenuedObj );
					newMenu( currMenuedObj );
					lastMenuedObj = currMenuedObj;
				}
			}
		}
		else // if didnt click anything
		{
			if( currHoverObj != null )
			{
				currHoverObj.renderer.material = originalMat;
			}

			if( Input.GetMouseButtonDown( 0 ) )
			{
				if( menu != null )
				{
					deleteMenu( menu, lastMenuedObj );
				}
			}
		}



	}
}
