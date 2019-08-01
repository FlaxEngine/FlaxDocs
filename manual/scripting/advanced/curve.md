# Curve

Engine API contains **Curve&lt;T&gt;** type that can be very useful for animations driven via game code. For instance, you can expose the curve, edit it in the editor and then use to perform smooth animation.

Here is sa sample script that shows how to use a curves:

```cs
public class CustomCurve : Script
{
    public Curve<float> FloatCurve = new Curve<float>(new Curve<float>.Keyframe(0, 0), new Curve<float>.Keyframe(1, 1));

    public Curve<Vector2> Vector2Curve = new Curve<Vector2>();

    public Curve<Vector3> Vector3Curve = new Curve<Vector3>();

    private float start;
    public float speed = 0.1f;

    private void Start()
    {
        start = Time.GameTime;
    }

    private void Update()
    {
        var time = (Time.GameTime - start) * speed;

        FloatCurve.Evaluate(out var floatValue, time);
        Vector2Curve.Evaluate(out var vector2Curve, time);
        Vector3Curve.Evaluate(out var vector3Curve, time);

        Debug.Log(string.Format("At {0}: float: {1}, vec2: {2}, vec3: {3}", time, floatValue, vector2Curve, vector3Curve));
    }
}
```

