using FlaxEngine;
using FlaxEngine.GUI;

public class ControlExample : Control
{
    private bool outlineBlack;



    public override void Draw()
    {
        // Draw the control using Render2D
        Rectangle rect = new Rectangle(Float2.Zero, Width, Height);
        Render2D.FillRectangle(rect, IsMouseOver ? Color.Green : Color.Red);
        Render2D.DrawRectangle(rect, outlineBlack ? Color.Black : Color.White);
    }

    public override bool OnKeyDown(KeyboardKeys key)
    {
        // Check if the pressed key was the C key
        if (key == KeyboardKeys.C)
        {
            outlineBlack = !outlineBlack;
            return true;
        }

        return false;
    }
}
