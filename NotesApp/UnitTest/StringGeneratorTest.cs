using NotesApp.Tools;
using Xunit;
using System;


namespace UnitTest
{
    public class StringGeneratorTest
    {
        [Fact]
        public void StringGenerator_Return_Empty_If_Length_Is_Zero()
        {
            int zero = 0;
            string check = StringGenerator.GenerateNumbersString(zero, true);
            string expected = String.Empty;
            Assert.Equal(check,expected);
        }

        [Fact]
        public void StringGenerator_Failed_If_Value_Is_Invalid()
        {
            int invalidLenght = -15;
            Assert.ThrowsAny<ArgumentException>(() => StringGenerator.GenerateNumbersString(invalidLenght, true));
        }

        [Fact]
        public void StringGenerator_Generate_String_Without_Zero_First()
        {
            bool allowLeadingZero = false;
            int length = 5;
            string check = StringGenerator.GenerateNumbersString(length, allowLeadingZero);
            Assert.False(check.ToCharArray()[0] == '0');
        }
        [Fact]
        public void StringGenerator_Return_String_With_Valid_Length()
        {
            int length = 5;
            string check = StringGenerator.GenerateNumbersString(length, false);
            Assert.Equal(check.Length,length);
        }
        [Fact]
        public void StringGenerator_Return_String_With_Valid_Length_And_Can_be_Parsed()
        {
            int length = 25;
            string check = StringGenerator.GenerateNumbersString(length, false);
            Assert.Equal(check.Length, length);
            Assert.True(decimal.TryParse(check,out _ ));
        }

    }
}