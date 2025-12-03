using UnityEngine;
public class Shoot : MonoBehaviour
{

    //snelheid waarmee de lijn groeit
    [SerializeField] private float lineSpeed = 10f;
    //verwijzing naar de linerenderer
    private LineRenderer _line;
    //we houden hiermee bij of de lijn actief is of niet
    private bool _lineActive = false;

    //snelheid waarmee de lijn groeit
    [SerializeField] private float lineSpeed_original = 10f;
    //verwijzing naar de linerenderer
    private LineRenderer _line_original;
    //we houden hiermee bij of de lijn actief is of niet
    private bool _lineActive_original = false;

    //in de inspector moet de prefab van de bal in dit veld (variabele) gesleept worden.
    [SerializeField] private GameObject prefab;
    //kracht die de bal krijgt per seconde dat we de knop inhouden
    [SerializeField] private float forceBuild = 20f;
    //maximale tijd om bij te houden hoe lang we de knop hebben ingedrukt
    [SerializeField] private float maximumHoldTime = 5f;
    [SerializeField] private float maxLineLength = 2f;

    //Deze variabelen zijn niet zichtbaar in de inspector

    //Bijhouden hoe lang we de knop hebben ingedrukt (seconden)
    private float _pressTimer = 0f;
    //Totale kracht waarmee de bal wordt afgevoord
    private float _launchForce = 0f;

    private void Start()
    {
        //we vragen het Line Renderer component op en slaan deze op in een variabele zodat we er later dingen mee kunnen doen
        _line = GetComponent<LineRenderer>();
        //We pakken het eindpunt van de lijn en zetten deze op positie 0,0,0 (zelfde plek als het beginpunt). Hierdoor word de lijn onzichtbaar.
        _line.SetPosition(1, Vector3.zero);
    }

    //Elk frame voeren we een functie HandleShot uit
    private void Update()
    {
        HandleShot();

    }

    private void HandleShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0;
            _lineActive = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _launchForce = _pressTimer * forceBuild;
            GameObject ball = Instantiate(prefab, transform.parent);
            ball.transform.rotation = transform.rotation;
            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse);
            ball.transform.position = transform.position;

            _lineActive = false;
            _line.SetPosition(1, Vector3.zero);
        }

        if (_pressTimer < maximumHoldTime)
        {
            _pressTimer += Time.deltaTime;
        }

        if (_lineActive)
        {
            float stretch = _pressTimer * lineSpeed;
            stretch = Mathf.Min(stretch, maxLineLength);

            _line.SetPosition(1, Vector3.left * stretch);
        }
    }
}
