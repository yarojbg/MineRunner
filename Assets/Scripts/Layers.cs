using UnityEngine;

public class Layers : MonoBehaviour
{
	public const int Enemy =  8;
	public const int Mine =  6;
	public const int Player =  7;
	public const int EnemyMask = 1 << Enemy;
	public const int MineMask = 1 << Mine;
	public const int PlayerMask = 1 << Player;


}
