using UnityEngine;
using System.Collections;

public static class ConstantsLib
{
// Projectiles
	// WBC
	public const float WBC_PROJ_SPEED = 100f;
	public const float WBC_PROJ_RANGE = 100f;

// Towers
	//WBC
	public const int WBC_COST = 100;

	public const float WBC_RELOAD_TIME = 2f;
	public const float WBC_TURN_SPEED = 5f;

// TilesMenu
	public const int RAY_CAST_DIST = 100000;

	public const float Y_OFFSET = 2.5f;

	public const string PLACEMENT_OPEN = "PlacementPlane_OPEN";
	public const string PLACEMENT_CLOSED = "PlacementPlane_CLOSED";
	public const string RAY_CAST_LAYER_NAME = "Placement";

	public const string TOWER_MENU_PATH = "Prefabs/Menus/towerMenu";
	public const string WBC_PATH = "Prefabs/TowerPrefabs/wbc";
	public const string MUCUS_PATH = "Prefabs/TowerPrefabs/mucus";
	public const string SYRINGE_PATH = "Prefabs/TowerPrefabs/syringe";
	public const string MORTAR_PATH = "Prefabs/TowerPrefabs/mortar";
	public const string TESLA_PATH = "Prefabs/TowerPrefabs/tesla";
	public const string CAM_NAME = "Camera";


}
