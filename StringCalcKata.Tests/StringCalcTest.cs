using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StringCalcKata;
using System.IO;

namespace StringCalcKata.Tests
{
    public class StringCalcTest
    {

        private void CalculateString(string input, int expectedResult)
        {
            var result = Calculator.Add(input);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenEmptyStringReturnZero()
        {
            CalculateString("", 0);
        }

        [Fact]
        public void GivenString1Returns1()
        {
            CalculateString("1", 1);
        }

        [Fact]
        public void Given_String_12_return_3()
        {
            CalculateString("1,2", 3);
        }

        [Fact]
        public void Given_String_1234567_return_28()
        {
            CalculateString("1,2,3,4,5,6,7", 28);
        }

        [Fact]
        public void Given_String_1NewLine2Comma3_return_6()
        {
            CalculateString("1\n2,3", 6);
        }

        [Fact]
        public void Given_String_1CommaNewLine_throwsFormatException()
        {
            Assert.Throws<FormatException>(() => { CalculateString("1,\n", 0); });
        }

        [Fact]
        public void Given_Input_with_semicolon_separator()
        {
            CalculateString("//;\n1;2", 3);
        }

        [Fact]
        public void Given_Input_with_minus_separator()
        {
            CalculateString("//-\n1-2", 3);
        }

        [Fact]
        public void Given_negative_number_throwsException()
        {
            Assert.Throws<Exception>(() => { CalculateString("-1", 0); });
        }

        [Fact]
        public void Given_negative_number_throwsException_With_Message()
        {
            try
            {
                CalculateString("-1", 0);
            }
            catch (Exception ex)
            {
                Assert.True(ex.Message.Contains("negatives not allowed"));
                Assert.True(ex.Message.Contains("-1"));
            }

        }

        [Fact]
        public void Given_negative_number_throwsException_Specifying_invalid_numbers()
        {
            try
            {
                CalculateString("-1,-2", 0);
            }
            catch (Exception ex)
            {
                Assert.True(ex.Message.Contains("negatives not allowed"));
                Assert.True(ex.Message.Contains("-1"));
                Assert.True(ex.Message.Contains("-2"));
            }
        }

        [Fact]
        public void Ignore_number_larger_than_one_Thousand()
        {
            CalculateString("2,1001", 2);
        }

        [Fact]
        public void Delimiter_of_any_lenght()
        {
            CalculateString("//[***]\n1***2***3", 6);
        }

        [Fact]
        public void Multiple_Delimiter_of_any_lenght()
        {
            CalculateString("//[*][%]\n1*2%3", 6);
        }

        [Fact]
        public void Multiple_Delimiter_of_multiple_lenght()
        {
            CalculateString("//[**][%%]\n1**2%%3", 6);
        }

        [Fact]
        public void Multiple_delimiter_test()
        {
            var delimiters=Calculator.GetMultipleDelimiters("//[*][%]\n1*2%3");
            Assert.Contains("*", delimiters);
            Assert.Contains("%", delimiters);
        }

        [Fact]
        public void Write_Result_To_Console()
        {
            var sb = new StringBuilder();
            var t = new StringWriter(sb);
            Console.SetOut(t);

            Calculator.Add("//[*][%]\n1*2%3");

            Assert.Equal("6\r\n", sb.ToString());
        }

        [Fact(Skip="")]
        public void Input_scalc_value_writes_result_to_console()
        {

            var sb = new StringBuilder();
            var t = new StringWriter(sb);
            Console.SetOut(t);

            //Calculator.Main(new string[]);

            // skapa GetNextInput()


            //Calculator.Add("//[*][%]\n1*2%3");

            Assert.Equal("6\r\n", sb.ToString());

        }

    }
}
