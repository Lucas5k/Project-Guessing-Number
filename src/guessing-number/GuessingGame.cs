using System;

namespace guessing_number;

public class GuessNumber
{
    //In this way we are passing the random number generator by dependency injection
    private IRandomGenerator random;
    public GuessNumber() : this(new DefaultRandom()){}
    public GuessNumber(IRandomGenerator obj)
    {
        this.random = obj;

        userValue = 0;
        randomValue = 0;
    }

    //user variables
    public int userValue;
    public int randomValue;


    public string Greet()
    {
        return "---Bem-vindo ao Guessing Game---Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!";
    }

    public string ChooseNumber(string userEntry)
    {
        throw new NotImplementedException();
    }

    public string RandomNumber()
    {
        throw new NotImplementedException();
    }

    public string AnalyzePlay()
    {
        throw new NotImplementedException();
    }
}
