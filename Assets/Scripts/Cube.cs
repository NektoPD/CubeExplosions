using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RandomMaterialColorChanger))]
[RequireComponent(typeof(CubeGenerator))]
public class Cube : MonoBehaviour, IPointerClickHandler
{
    private Rigidbody _rigidbody;
    private CubeGenerator _cuTubeGenerator;
    private int _currentCubeGenarationPossibility = 100;
    private int _minCubeGenrationPossibility = 1;
    private int _maxCubeGenrationPossibility = 101;
    private float _explosionForce = 3;
    private float _explosionRadius = 2;
    private int _scaleDivider = 2;

    public Cube GetCube => this;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _cuTubeGenerator = GetComponent<CubeGenerator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int probability = Random.Range(_minCubeGenrationPossibility, _maxCubeGenrationPossibility);

        if (probability <= _currentCubeGenarationPossibility)
        {
            _cuTubeGenerator.GenerateCube();
        }

        gameObject.SetActive(false);
    }

    public void Init()
    {
        transform.localScale /= _scaleDivider;
        _rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        ReduceGenerationPossibilityByHalf();
    }

    private void ReduceGenerationPossibilityByHalf()
    {
        _currentCubeGenarationPossibility /= 2;
    }
}
