using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;
using System;
using TemplateConsoleApp;

namespace TemplateConsoleApp.Tests
{
    public class Tests
    {
        private RomanKata solution;

        [SetUp]
        public void Setup()
        {
            solution = new RomanKata();
        }


        [Test]
        //
        public void Test_Value_For_Minimum()
        {
            solution.ConvertToRoman(1).Should().Be("I");
        }

        [Test]
        public void Test_Value_For_Maximum()
        {
            solution.ConvertToRoman(4000).Should().Be("MMMM");
        }

        [Test]
        public void Test_Value_For_Longest_String()
        {
            solution.ConvertToRoman(3888).Should().Be("MMMDCCCLXXXVIII");
        }


        [Test]
        public void Test_Value_For_69()
        {
            solution.ConvertToRoman(69).Should().Be("LXIX");
        }

        [Test]
        public void Test_Value_For_420()
        {
            solution.ConvertToRoman(420).Should().Be("CDXX");
        }

        [Test]
        public void Test_Value_For_1337()
        {
            solution.ConvertToRoman(1337).Should().Be("MCCCXXXVII");
        }

        [Test]
        public void Test_Value_For_MCCCXXXVII()
        {
            solution.ConvertToArabic("MCCCXXXVII").Should().Be(1337);
        }

        [Test]
        public void Test_Value_For_CDXX()
        {
            solution.ConvertToArabic("CDXX").Should().Be(420);
        }


    }
}
