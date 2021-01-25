using Xunit;
using System;

using NotesApp.Tools;

namespace UnitTest
{
    public class NumberGeneratorTest
    {
        [Fact]
        public void NumberGenerator_Failed_If_Argument_Is_Invalid()
        {
            int length = 20;
            Assert.Throws<ArgumentOutOfRangeException>(()=>NumberGenerator.GeneratePositiveLong(length));
        }
        [Fact]
        public void NumberGenerator_Return_Valid_Number()
        {
            int length = 15;
            var num = NumberGenerator.GeneratePositiveLong(15);
            Assert.Equal(num.ToString().Length.ToString(),length.ToString());
        }
    }
}