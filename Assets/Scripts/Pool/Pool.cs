using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private T _prefab;

    protected ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>
            (
            createFunc: () => CreateObject(),
            actionOnGet: (obj) => Spawn(obj)
            );
    }

    public T GetObject()
    {
        return _pool.Get();
    }

    public void Reset()
    {
        for (int i = 0; i < _container.childCount; i++)
        {
            _container.GetChild(i).gameObject.TryGetComponent(out T spawnedObject);

            if (spawnedObject.isActiveAndEnabled == true)
                OnRelease(spawnedObject);
        }
    }

    protected virtual void OnRelease(T spawnedObject)
    {
        spawnedObject.gameObject.SetActive(false);
        _pool.Release(spawnedObject);
    }

    protected virtual void Spawn(T spawnedObject)
    {
        spawnedObject.gameObject.SetActive(true);
    }

    private T CreateObject()
    {
        T spawned = Instantiate(_prefab);
        spawned.transform.parent = _container;

        return spawned;
    }
}
