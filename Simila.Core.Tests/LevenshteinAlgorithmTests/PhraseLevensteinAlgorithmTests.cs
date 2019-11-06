﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simila.Core.Levenstein;

namespace Simila.Core.Tests.LevenshteinAlgorithmTests
{
    [TestClass]
    class PhraseLevensteinAlgorithmTests
    {
        [TestMethod]
        public void PhraseLevensteinAlgorithm_ShouldWork_Default()
        {
            var algorithm =
                new LevensteinAlgorithm<Phrase, Word>(
                    new WordSimilarityResolverDefault()
                );

            AreSimilar(algorithm, "Mehran Davoudi", "Nehran Dawoody");
            AreSimilar(algorithm, "Afshin Alizadeh", "Aphshin Alizade");

            NotSimilar(algorithm, "Lilian Alpha", "Lamborghini Beta");
            NotSimilar(algorithm, "Crash the world", "Clash of clawns");
        }


        private void AreSimilar(LevensteinAlgorithm<Phrase, Word> algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity(left, right);
            Assert.IsTrue(similarity > 0.6, string.Format("{0}-{1} should be similar (Similarity: {2})", left, right, similarity));
        }

        private void NotSimilar(LevensteinAlgorithm<Phrase, Word> algorithm, string left, string right)
        {
            var similarity = algorithm.GetSimilarity(left, right);
            Assert.IsTrue(similarity < 0.5, string.Format("{0}-{1} should NOT be similar (Similarity: {2})", left, right, similarity));
        }
    }
}
