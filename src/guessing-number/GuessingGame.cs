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
        return "---Bem-vindo ao Guessing Game--- /n Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!";
    }

    public string ChooseNumber(string userEntry)
    {
        bool isNumber = int.TryParse(userEntry, out int convertToInt);

        if(!isNumber) {
            return "Entrada inválida! Não é um número.";
        }

        if(convertToInt < -100 || convertToInt > 100) {
            return "Entrada inválida! Valor não está no range.";
        }
        else {
            userValue = convertToInt;
        }
        return "Número escolhido!";
    }

    public string RandomNumber()
    {
        randomValue = random.GetInt(-100, 100);

        return "A máquina escolheu um número de -100 à 100!";
    }

    public string AnalyzePlay()
    {
        throw new NotImplementedException();
    }
}
