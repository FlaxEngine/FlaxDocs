# Curve

Engine API contains **BezierCurve&lt;T&gt;** and **LinearCurve&lt;T&gt;** types that can be very useful for animations driven via game code. For instance, you can expose the curve, edit it in the editor and then use to perform smooth animation.

Here is sa sample script that shows how to use a curves:

```cs
public class CustomCurve : Script
{
    public BezierCurve<float> FloatCurve = new BezierCurve<float>(new BezierCurve<float>.Keyframe(0, 0), new BezierCurve<float>.Keyframe(1, 1));

    public BezierCurve<Vector2> Vector2Curve = new BezierCurve<Vector2>();

    public BezierCurve<Vector3> Vector3Curve = new BezierCurve<Vector3>();

    private float start;
    public float speed = 0.1f;

    public override void OnStart()
    {
        start = Time.GameTime;
    }

    public override void OnUpdate()
    {
        var time = (Time.GameTime - start) * speed;

        FloatCurve.Evaluate(out var floatValue, time);
        Vector2Curve.Evaluate(out var vector2Curve, time);
        Vector3Curve.Evaluate(out var vector3Curve, time);

        Debug.Log(string.Format("At {0}: float: {1}, vec2: {2}, vec3: {3}", time, floatValue, vector2Curve, vector3Curve));
    }
}
```

