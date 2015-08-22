using NUnit.Framework;
using Townsend.Domain.Models;

namespace Townsend.DomainTests
{
    public class WeightCalculatorTests
    {
        private readonly object[] _weightTestCases = 
        { 
            new object[]{ new Weight(170,15), new Weight(70,8), new Weight(100,7)},  //case 1
            new object[] {new Weight(170,15), new Weight(70,8), new Weight(100,7)}, //case 2                        
            new object[] {new Weight(210,5), new Weight(125,4), new Weight(85,1)} //case 3                        
        };

        [Test, TestCaseSource("_weightTestCases")]
        public void Should_Add2WeightsTogether(Weight expectedResult, Weight weight1, Weight weight2)
        {
            var result = weight1 + weight2;

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}