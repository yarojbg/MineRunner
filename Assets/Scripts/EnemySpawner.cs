using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private Transform _enemy;

	[SerializeField]
	private Transform _mine;

	[SerializeField]
	private float _timeBetweenSpawns;

	[SerializeField]
	private float _mineCount;

	[SerializeField]
	private float XAxisMinValue = -45;
	[SerializeField]
	private float XAxisMaxValue = 45;
	[SerializeField]
	private float ZAxisMinValue = -45;
	[SerializeField]
	private float ZAxisMaxValue = 45;

    [SerializeField]
	private  float _radiusOfCheck;

	const int layerMaskNotToSpawn = Layers.PlayerMask + Layers.EnemyMask + Layers.MineMask;
	


	void Start()
    {
		SpawnMines();
        StartCoroutine(SpawnEnemiesWithInterval());
    }

	void SpawnMines()
	{
		for (int i = 0; i < _mineCount; i++)
		{
			Instantiate(_mine, RandomSpawnPosition(), Quaternion.identity);
		}
	}

	IEnumerator SpawnEnemiesWithInterval()
    {
        yield return new WaitForSeconds(_timeBetweenSpawns);
        Instantiate(_enemy, RandomSpawnPosition(),Quaternion.identity);

    }

    private Vector3 RandomSpawnPosition()
    {
        while (true) {
            var positionCandidate = new Vector3(
                Random.Range(XAxisMinValue, XAxisMaxValue),
                1f,
                Random.Range(ZAxisMinValue, ZAxisMaxValue));

            if (Physics.OverlapSphere(positionCandidate, _radiusOfCheck, layerMaskNotToSpawn).Length == 0)
                return positionCandidate;

    } }

}
