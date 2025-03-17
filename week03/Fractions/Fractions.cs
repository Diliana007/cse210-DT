using System;

public class Fraction
{
    
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top =1;
        _bottom =1;
    }

    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        if(bottom ==0)
        {
            throw new ArgumentException("Denominator cannot be zero. ");
        }
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        return top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        if (bottom ==0)
        {
            throw new ArgumentException("Denominator cannot be zero. ");
        }
        _bottom = bottom;
    }
}
)
