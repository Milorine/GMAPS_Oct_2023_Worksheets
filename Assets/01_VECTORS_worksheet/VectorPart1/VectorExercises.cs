using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY, minZ, maxZ;

    private void Start()
    {
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0);
        endPt = new Vector2(2, 3);

        drawnLine = lineFactory.GetLine(startPt, endPt,
                                               0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        for (int i = 0; i < n; i++)
        {   
            maxX = n;
            maxY = n;
            startPt = new Vector2(Random.Range(-maxX, maxX),Random.Range(-maxY, maxY));
            endPt = new Vector2(Random.Range(-maxX, maxX),Random.Range(-maxY, maxY));
            drawnLine = lineFactory.GetLine(startPt, endPt,
                                               0.02f, Color.black);
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {   
            maxX = n;
            maxY = n;
            maxZ =n;

            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), Random.Range(-maxZ, maxZ)),
                Color.white,
                60f);
        }
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a + b;
        HVector2D d = a - b;
        Vector2 veca = new Vector2(a.x, a.y);
        Vector2 vecb = new Vector2(b.x, b.y);
        Vector2 vecc = new Vector2(c.x, c.y);


        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, d.ToUnityVector3(), Color.white, 60f);
        Debug.Log("Magnitude of a = " + veca.magnitude.ToString("F2"));
        Debug.Log("Magnitude of b = " + vecb.magnitude.ToString("F2"));
        Debug.Log("Magnitude of c = " + vecc.magnitude.ToString("F2"));
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3,5);
        HVector2D b = a / 2;
        Vector3 c = new Vector3(1,0,0);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(c, b.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3,5);
        HVector2D b = new HVector2D(3,5);
        b.Normalize();
        Vector2 vecb = new Vector2(b.x, b.y);

        Vector3 c = new Vector3(1,0,0);
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(c, b.ToUnityVector3(), Color.green, 60f);
        Debug.Log("Magnitude of a = " + vecb.magnitude.ToString("F2"));

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D proj = c.Projection(b);

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
