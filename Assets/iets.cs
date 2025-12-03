using UnityEngine;

public class RandomItem : MonoBehaviour
{
    [SerializeField] string[] item;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) PrintRandomItem();
        if (Input.GetKeyDown(KeyCode.Escape)) PrintAllItems();
    }
    private void PrintRandomItem()
    {
        int i = Random.Range(0, item.Length);
        Debug.Log(item[i]);
    }
    private void PrintAllItems()
    {
        for (int i = 0; i < item.Length; i++)
        {
            Debug.Log(item[i]);
        }
    }
}