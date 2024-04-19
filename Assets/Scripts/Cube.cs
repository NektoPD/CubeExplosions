using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RandomMaterialColorChanger))]
[RequireComponent(typeof(CubeGenerator))]
public class Cube : MonoBehaviour, IPointerClickHandler
{
    private CubeGenerator _cuTubeGenerator;
    private int _currentCubeGenarationPossibility = 100;
    private int _minCubeGenrationPossibility = 0;
    private int _maxCubeGenrationPossibility = 100;

    private void Awake()
    {
        _cuTubeGenerator = GetComponent<CubeGenerator>();
    }

    public void ReduceGenerationPossibilityByHalf()
    {
        _currentCubeGenarationPossibility /= 2;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int probability = Random.Range(_minCubeGenrationPossibility, _maxCubeGenrationPossibility);

        if (probability <= _currentCubeGenarationPossibility)
        {
            _cuTubeGenerator.GenerateCube();
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
