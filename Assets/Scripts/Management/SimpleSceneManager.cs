using UnityEngine;

public class SimpleSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject[] LoadPrefab;

    private void Awake()
    {
        Load();
    }

    private void Load()
    {
        foreach (GameObject prefab in LoadPrefab)
        {
            Instantiate(prefab);
        }
    }

}

