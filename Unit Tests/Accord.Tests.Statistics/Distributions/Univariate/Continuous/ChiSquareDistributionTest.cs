﻿// Accord Unit Tests
// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © César Souza, 2009-2014
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

namespace Accord.Tests.Statistics
{
    using Accord.Statistics.Distributions.Univariate;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Accord.Controls;
    using Accord.Math;
    using Accord.Statistics.Testing;

    [TestClass()]
    public class ChiSquareDistributionTest
    {


        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod()]
        public void ConstructorTest()
        {
            var chisq = new ChiSquareDistribution(degreesOfFreedom: 7);

            double mean = chisq.Mean;     // 7
            double median = chisq.Median; // 6.345811195595612
            double var = chisq.Variance;  // 14
            double mode = chisq.Mode;     // 5.0

            double cdf = chisq.DistributionFunction(x: 6.27); // 0.49139966433823956
            double pdf = chisq.ProbabilityDensityFunction(x: 6.27); // 0.11388708001184455
            double lpdf = chisq.LogProbabilityDensityFunction(x: 6.27); // -2.1725478476948092

            double ccdf = chisq.ComplementaryDistributionFunction(x: 6.27); // 0.50860033566176044
            double icdf = chisq.InverseDistributionFunction(p: cdf); // 6.2700000000852318

            double hf = chisq.HazardFunction(x: 6.27); // 0.22392254197721179
            double chf = chisq.CumulativeHazardFunction(x: 6.27); // 0.67609276602233315

            string str = chisq.ToString(); // "χ²(x; df = 7)

            Assert.AreEqual(7, mean);
            Assert.AreEqual(6.345811195595612, median, 1e-6);
            Assert.AreEqual(14, var);
            Assert.AreEqual(5.0, mode);
            Assert.AreEqual(0.67609276602233315, chf);
            Assert.AreEqual(0.49139966433823956, cdf);
            Assert.AreEqual(0.11388708001184455, pdf);
            Assert.AreEqual(-2.1725478476948092, lpdf);
            Assert.AreEqual(0.22392254197721179, hf);
            Assert.AreEqual(0.50860033566176044, ccdf);
            Assert.AreEqual(6.2700000000852318, icdf, 1e-6);
            Assert.AreEqual("χ²(x; df = 7)", str);
        }

        [TestMethod()]
        public void MedianTest()
        {
            var target = new ChiSquareDistribution(degreesOfFreedom: 4);

            Assert.AreEqual(target.Median, target.InverseDistributionFunction(0.5));
        }

        [TestMethod()]
        public void ProbabilityDensityFunctionTest()
        {
            int degreesOfFreedom;
            double actual, expected, x;
            ChiSquareDistribution target;

            degreesOfFreedom = 1;
            target = new ChiSquareDistribution(degreesOfFreedom);
            x = 1;
            actual = target.ProbabilityDensityFunction(x);
            expected = 0.2420;
            Assert.AreEqual(expected, actual, 1e-4);

            degreesOfFreedom = 2;
            target = new ChiSquareDistribution(degreesOfFreedom);
            x = 2;
            actual = target.ProbabilityDensityFunction(x);
            expected = 0.1839;
            Assert.AreEqual(expected, actual, 1e-4);

            degreesOfFreedom = 10;
            target = new ChiSquareDistribution(degreesOfFreedom);
            x = 2;
            actual = target.ProbabilityDensityFunction(x);
            expected = 0.0077;
            Assert.AreEqual(expected, actual, 1e-4);
        }

        [TestMethod()]
        public void LogProbabilityDensityFunctionTest()
        {
            int degreesOfFreedom;
            double actual, expected, x;
            ChiSquareDistribution target;

            degreesOfFreedom = 1;
            target = new ChiSquareDistribution(degreesOfFreedom);
            x = 1;
            actual = target.LogProbabilityDensityFunction(x);
            expected = System.Math.Log(target.ProbabilityDensityFunction(x));
            Assert.AreEqual(expected, actual, 1e-10);

            degreesOfFreedom = 2;
            target = new ChiSquareDistribution(degreesOfFreedom);
            x = 2;
            actual = target.LogProbabilityDensityFunction(x);
            expected = System.Math.Log(target.ProbabilityDensityFunction(x));
            Assert.AreEqual(expected, actual, 1e-10);

            degreesOfFreedom = 10;
            target = new ChiSquareDistribution(degreesOfFreedom);
            x = 2;
            actual = target.LogProbabilityDensityFunction(x);
            expected = System.Math.Log(target.ProbabilityDensityFunction(x));
            Assert.AreEqual(expected, actual, 1e-10);
        }

        [TestMethod()]
        public void DistributionFunctionTest()
        {
            int degreesOfFreedom;
            double actual, expected, x;
            ChiSquareDistribution target;

            degreesOfFreedom = 1;
            target = new ChiSquareDistribution(degreesOfFreedom);
            x = 5;
            actual = target.DistributionFunction(x);
            expected = 0.9747;
            Assert.AreEqual(expected, actual, 1e-4);


            degreesOfFreedom = 5;
            target = new ChiSquareDistribution(degreesOfFreedom);
            x = 5;
            actual = target.DistributionFunction(x);
            expected = 0.5841;
            Assert.AreEqual(expected, actual, 1e-4);
        }

        [TestMethod()]
        public void InverseTest()
        {
            double expected = 1.8307038053275149991e+01;
            double actual = ChiSquareDistribution.Inverse(0.95, 10);
            Assert.AreEqual(expected, actual, 1e-14);
        }

        [TestMethod()]
        public void InverseTest2()
        {
            double[] p = 
            {
                0.003898633, 0.956808760, 0.318487983,
                0.887227832, 0.641802182, 0.640345741,
                0.931996171, 0.426819547, 0.624824460,
                0.247553652, 0.282827901, 0.313780766,
                0.093206440, 0.392279489, 0.601228848
            };

            double[] expected = 
            {
                 2.3875256301085814295e-05, 4.0879013123718950240e+00, 1.6842875232305037914e-01,
                 2.5149366098649084122e+00, 8.4420178057142991612e-01, 8.3910013681477579883e-01,
                 3.3305572850409235208e+00, 3.1738990781989129264e-01, 7.8645062825981804089e-01,
                 9.9486814436765019787e-02, 1.3121839127554768556e-01, 1.6320884169279117892e-01,
                 1.3708641978779382772e-02, 2.6350767581793288485e-01, 7.1202870676363294589e-01,

            };


            double[] actual = new double[p.Length];
            for (int i = 0; i < actual.Length; i++)
                actual[i] = ChiSquareDistribution.Inverse(p[i], 1);

            Assert.IsTrue(expected.IsEqual(actual, 1e-14));
        }


    }
}
