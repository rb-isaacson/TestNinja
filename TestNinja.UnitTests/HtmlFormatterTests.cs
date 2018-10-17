using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");

            // this is specific: in this case, specific is good
            // in some cases, it may be more appropriate to be more general

            Assert.That(result, Is.EqualTo("<strong>abc</strong>"));

            // you can also ignore case
            Assert.That(result, Is.EqualTo("<strong>ABC</strong>").IgnoreCase);
            
            // examples of more general assertions that aren't good enough in this case
            // but they give you some ideas of how to be more general
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));

        }
    }
}
