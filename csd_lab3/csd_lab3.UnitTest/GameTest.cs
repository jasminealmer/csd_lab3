using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace csd_lab3.UnitTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TwoDepthTest()
        {
            var g = new Game();

            string[] testInput = new string[] { "NW.CC", "NC.CC", "NW.NW", "NE.CC", "NW.SE", "CE.CC", "CW.CC", "SE.CC", "CW.NW", "CC.CC", "CW.SE", "CC.NW", "CC.SE", "CE.NW", "SW.CC", "CE.SE", "SW.NW", "SE.SE", "SW.SE" };
            string expectedLargeCells = "NW, CW, SW";
            string expectedSmallCells = "NW.CC, NW.NW, NW.SE, CW.CC, CW.NW, CW.SE, SW.CC, SW.NW, SW.SE";
            string expectedWins = "1.3, 0.1";
            _ = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> testResults = g.PlayGame(testInput);

            List<string> separatedTestResults = new List<string>();

            foreach (var result in testResults)
            {
                string concatValues = string.Join(", ", result.Value.ToArray());
                separatedTestResults.Add(concatValues);
            }

            Assert.AreEqual(separatedTestResults[0], expectedLargeCells);
            Assert.AreEqual(separatedTestResults[1], expectedSmallCells);
            Assert.AreEqual(separatedTestResults[2], expectedWins);

        }
    }
}
