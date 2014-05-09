using UnityEngine;
using System.Collections;

public static class ConstantsLib
{

// GameEngine
	public const string GAME_ENGINE_NAME = "A - GameEngine";
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
	public const float Y_OFFSET = 2.5f;

	// TILE TAGS
	public const string PLACEMENT_OPEN = "PlacementPlane_OPEN";
	public const string PLACEMENT_CLOSED = "PlacementPlane_CLOSED";
	public const string PLACEMENT_MENUED = "PlacementPlane_MENUED";

	// MENU ICON TAGS
	public const string WBC_ICON_TAG = "Wbc_icon";
	public const string MUCUS_ICON_TAG = "Mucus_icon";
	public const string MORTAR_ICON_TAG = "Mortar_icon";
	public const string SYRINGE_ICON_TAG = "Syringe_icon";
	public const string TESLAS_ICON_TAG = "Tesla_icon";

	// LAYER NAMES
	public const string RAY_CAST_TILES = "Placement";
	public const string RAY_CAST_WBC = "wbc_icon";
	public const string RAY_CAST_MUCUS = "mucus_icon";
	public const string RAY_CAST_MORTAR = "mortar_icon";
	public const string RAY_CAST_SYRINGE = "syringe_icon";
	public const string RAY_CAST_TESLA = "tesla_icon";

	// PREFAB PATHS
	public const string TOWER_MENU_PATH = "Prefabs/Menus/towerMenu";
	public const string WBC_PATH = "Prefabs/TowerPrefabs/wbc";
	public const string MUCUS_PATH = "Prefabs/TowerPrefabs/mucus";
	public const string SYRINGE_PATH = "Prefabs/TowerPrefabs/syringe";
	public const string MORTAR_PATH = "Prefabs/TowerPrefabs/mortar";
	public const string TESLA_PATH = "Prefabs/TowerPrefabs/tesla";
	public const string CAM_NAME = "Camera";


}
