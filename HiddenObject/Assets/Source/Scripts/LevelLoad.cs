using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] private AssetReference _galery;

    private async void Start()
    {
        AsyncOperationHandle<GameObject> handle = _galery.LoadAssetAsync<GameObject>();
        await handle.Task;

        if(handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject gameObject = handle.Result;
            GameObject prefab = Instantiate(gameObject, transform);
            prefab.transform.SetSiblingIndex(1);
            Addressables.Release(handle);
        }
    }
}
