using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Constructor: defaults to 1/1
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor: takes numerator, sets denominator to 1
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Constructor: takes both numerator and denominator
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getter for numerator
    public int GetNumerator()
    {
        return _numerator;
    }

    // Setter for numerator
    public void SetNumerator(int value)
    {
        _numerator = value;
    }

    // Getter for denominator
    public int GetDenominator()
    {
        return _denominator;
    }

    // Setter for denominator
    public void SetDenominator(int value)
    {
        _denominator = value;
    }

    // Return fraction string (e.g. 3/4)
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Return decimal value (e.g. 0.75)
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
