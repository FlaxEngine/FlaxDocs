# Slider

![Slider](media/slider.png)

The **Slider** responds to a value changed event from the user to change a value.

# Usage

Here is a c# example of how to get and use a slider's `ValueChanged` event in a script:

```cs
public UIControl SliderUIControl;
private Slider _slider;

public override void OnStart()
{
    if (SliderUIControl)
        _slider = SliderUIControl.Get<Slider>();
    if (_slider != null)
        _slider.ValueChanged += OnValueChanged;
}

private void OnValueChanged()
{
    Debug.Log($"Slider Value changed to {_slider.Value}");
}

public override void OnDestroy()
{
    if (_slider != null)
        _slider.ValueChanged -= OnValueChanged;
}
```