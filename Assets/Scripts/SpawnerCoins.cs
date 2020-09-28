using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform _spawnerPoints;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnerPoints.childCount];

        for (int i = 0; i < _spawnerPoints.childCount; i++)
        {
            _points[i] = _spawnerPoints.GetChild(i);
        }

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_coin, _points[i].transform.position, Quaternion.identity);
        }
    }
}
