using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace csd_lab3.UnitTest
{
    [TestClass]
    public class ParseTest
    {
        [TestMethod]
        public void ValidCharacters_IsTrue()
        {
            var p = new Parse();

            string[] testInput = new string[] { "NW.CC", "NC.CC", "NW.NW", "NE.CC", "NW.SE", "CE.CC", "CW.CC", "SE.CC", "CW.NW", "CC.CC", "CW.SE", "CC.NW", "CC.SE", "CE.NW", "SW.CC", "CE.SE", "SW.NW", "SE.SE", "SW.SE" };
            var result = p.ValidCharacters(testInput);

            Assert.IsTrue(result);
        }
    }
}
