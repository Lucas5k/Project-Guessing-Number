using Xunit;
using System.IO;
using System;
using Moq;
using guessing_number;
using FluentAssertions;

namespace guessing_number.Test;

[Collection("Sequential")]
public class TestSecondReq
{
    [Theory(DisplayName = "Deve escolher randomicamente um número entre -100 e 100!")]
    [InlineData(-100, 100)]
    public void TestRandomlyChooseANumber(int MinimumRange, int MaximumRange)
    {
        GuessNumber random = new();
        random.randomValue.Should().Be(0);

        random.RandomNumber();

        random.randomValue.Should().BeInRange(MinimumRange, MaximumRange);
        random.RandomNumber().Should().Be("A máquina escolheu um número de -100 à 100!");
    }

    [Theory(DisplayName = "Deve comparar a entrada do usuário em um caso MENOR")]
    [InlineData(50, 30)]
    [InlineData(50, 10)]
    [InlineData(50, -100)]
    [InlineData(50, 49)]
    [InlineData(50, 0)]
    public void TestProgramComparisonValuesLess(int mockValue, int entry)
    {
        GuessNumber instance = new();

        instance.AnalyzePlay();

        instance.userValue.Should().Be(0);
        instance.randomValue.Should().Be(0);

        var mock = new Moq.Mock<IRandomGenerator>();
        mock.Setup(m => m.GetInt(-100, 100)).Returns(mockValue);

        instance.randomValue = mock.Object.GetInt(-100, 100);
        var convertToString = Convert.ToString(entry);

        instance.ChooseNumber(convertToString);

        instance.AnalyzePlay().Should().Be("Tente um número MAIOR");
    }
    [Theory(DisplayName = "Deve comparar a entrada do usuário em um caso MAIOR")]
    [InlineData(50, 60)]
    [InlineData(50, 90)]
    [InlineData(50, 100)]
    [InlineData(50, 51)]
    [InlineData(50, 77)]
    public void TestProgramComparisonValuesBigger(int mockValue, int entry)
    {
        GuessNumber instance = new();

        instance.AnalyzePlay();

        instance.userValue.Should().Be(0);
        instance.randomValue.Should().Be(0);

        var mock = new Moq.Mock<IRandomGenerator>();
        mock.Setup(m => m.GetInt(-100, 100)).Returns(mockValue);

        instance.randomValue = mock.Object.GetInt(-100, 100);
        var convertToString = Convert.ToString(entry);

        instance.ChooseNumber(convertToString);
        instance.AnalyzePlay().Should().Be("Tente um número MENOR");
    }

    [Theory(DisplayName = "Deve comparar a entrada do usuário em um caso IGUAL")]
    [InlineData(50, 50)]
    [InlineData(100, 100)]
    [InlineData(-99, -99)]
    [InlineData(0, 0)]
    [InlineData(77, 77)]
    public void TestProgramComparisonValuesEqual(int mockValue, int entry)
    {
        GuessNumber instance = new();

        instance.AnalyzePlay();

        instance.userValue.Should().Be(0);
        instance.randomValue.Should().Be(0);

        var mock = new Moq.Mock<IRandomGenerator>();
        mock.Setup(m => m.GetInt(-100, 100)).Returns(mockValue);

        instance.randomValue = mock.Object.GetInt(-100, 100);
        var convertToString = Convert.ToString(entry);

        instance.ChooseNumber(convertToString);
        instance.AnalyzePlay().Should().Be("ACERTOU!");    }
}
