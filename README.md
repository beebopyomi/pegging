This is my beggining of a new game! peggle 2.0! 

better then the remakes that they made after the first one........

<img width="650" height="676" alt="obraz" src="awsd.png"/>

als je de video zoekt van de demo het is de enigste mp4 file in de repo dus yea

hier is de code

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

