﻿using System;
using NUnit.Framework;

namespace Simila.Core.Tests
{
    [TestFixture]
    public class SimpleTests
    {
        [Test]
        public void SimpleDemoMustWork()
        {

            var similaComparer = new Simila {Treshold = 0.7};

            Assert.IsTrue(similaComparer.IsSimilar("Mehran", "Nehran"));

        }
    }
}
