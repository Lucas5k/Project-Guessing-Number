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
        int convertToInt;
        int userValue;
        bool isNumber = int.TryParse(userEntry, out convertToInt);

        if(!isNumber) {
            return "Entrada inválida! Não é um número.";
        }

        if(convertToInt <= -100 && convertToInt >= 100) {
            userValue = 0;
            return "Entrada inválida! Valor não está no range.";
        }

        userValue = convertToInt;
        return "Número escolhido!";
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
