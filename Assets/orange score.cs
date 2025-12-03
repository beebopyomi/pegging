using UnityEngine;

public class orangescore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("orange Hit!");
        ScoreManager.Instance.AddScore(100);
        Destroy(gameObject, 0.2f);
    }
}