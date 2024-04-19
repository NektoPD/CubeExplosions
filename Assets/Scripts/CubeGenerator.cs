using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    private Cube _clonePrefab;
    private Vector3 _initialScale;
    private int _minCubeCount = 2;
    private int _maxCubeCount = 6;
    private float _explosionForce = 3;
    private float _explosionRadius = 2;
    private int _scaleDivider = 2;

    private void Awake()
    {
        _clonePrefab = this.GetComponent<Cube>();
        _initialScale = transform.localScale;
    }

    public void GenerateCube()
    {
        int cubeCount = Random.Range(_minCubeCount, _maxCubeCount);

        for (int i = 0; i < cubeCount; i++)
        {
            Cube newCube = Instantiate(_clonePrefab, transform.position, Quaternion.identity);
            newCube.transform.localScale /= _scaleDivider;
            newCube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            newCube.ReduceGenerationPossibilityByHalf();
        }
    }
}
