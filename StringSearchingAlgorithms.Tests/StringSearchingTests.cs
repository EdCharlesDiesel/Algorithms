using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace StringSearchingTests
{
    [TestClass]
    public class SearchAlgorithms : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new NaiveStringSearch() };
            yield return new object[] { new BoyerMooreHorspool() };
        }

        IEnumerator IEnumerable.GetEnumerator() { GetEnumerator();}
    }

    [TestClass]
    public class StringSearchingTests
    {
        [TestMethod]
        public void SearchForMissingMatch(IStringSearchAlgorithm algorithm)
        {
            string toFind = "missing data";
            string toSearch = "this string does not contain the missing string data";

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches);
            Assert.IsNull(matches);
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void EmptySourceString(IStringSearchAlgorithm algorithm)
        {
            string toFind = string.Empty;
            string toSearch = "this string does not contain the missing string data";

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches);
            Assert.Empty(matches);
        }

        //[Theory]
        //[ClassData(typeof(SearchAlgorithms))]
        //public void NullSourceString(IStringSearchAlgorithm algorithm)
        //{
        //    string toFind = null;
        //    string toSearch = "this string does not contain the missing string data";

        //    Assert.Throws<ArgumentNullException>(() => algorithm.Search(toFind, toSearch).ToArray());
        //}

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]

        public void EmptyTargetString(IStringSearchAlgorithm algorithm)
        {
            string toFind = "missing data";
            string toSearch = string.Empty;

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches);
            Assert.IsNull(matches);
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void NullTargetString(IStringSearchAlgorithm algorithm)
        {
            string toFind = "missing data";
            string toSearch = null;

            Assert.<ArgumentNullException>(() => algorithm.Search(toFind, toSearch).ToArray());
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void EmptyEmpty(IStringSearchAlgorithm algorithm)
        {
            string toFind = string.Empty;
            string toSearch = string.Empty;

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.NotNull(matches);
            Assert.Empty(matches);
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void ExactSingleCharMatch(IStringSearchAlgorithm algorithm)
        {
            string toFind = "f";
            string toSearch = "f";

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.NotNull(matches);
            Assert.Single(matches);
            Assert.Equal(0, matches[0].Start);
            Assert.Equal(toFind.Length, matches[0].Length);
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void ExactMatch(IStringSearchAlgorithm algorithm)
        {
            string toFind = "found";
            string toSearch = "found";

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.NotNull(matches);
            Assert.Single(matches);
            Assert.Equal(0, matches[0].Start);
            Assert.Equal(toFind.Length, matches[0].Length);
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void MultipleMatchesExactString(IStringSearchAlgorithm algorithm)
        {
            string toFind = "found";
            string toSearch = "foundfound";

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.NotNull(matches);
            Assert.Equal(2, matches.Length);

            Assert.Equal(0, matches[0].Start);
            Assert.Equal(toFind.Length, matches[0].Length);

            Assert.Equal(5, matches[1].Start);
            Assert.Equal(toFind.Length, matches[1].Length);
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void MultipleMatchesLeadingJunk(IStringSearchAlgorithm algorithm)
        {
            string toFind = "found";
            string toSearch = "leadingfoundfound";

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.NotNull(matches);
            Assert.Equal(2, matches.Length);

            Assert.Equal(7, matches[0].Start);
            Assert.Equal(toFind.Length, matches[0].Length);

            Assert.Equal(12, matches[1].Start);
            Assert.Equal(toFind.Length, matches[1].Length);
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void MultipleMatchesTrailingString(IStringSearchAlgorithm algorithm)
        {
            string toFind = "found";
            string toSearch = "foundfoundtrailing";

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.NotNull(matches);
            Assert.Equal(2, matches.Length);

            Assert.Equal(0, matches[0].Start);
            Assert.Equal(toFind.Length, matches[0].Length);

            Assert.Equal(5, matches[1].Start);
            Assert.Equal(toFind.Length, matches[1].Length);
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void MultipleMatchesMiddleString(IStringSearchAlgorithm algorithm)
        {
            string toFind = "found";
            string toSearch = "found and found";

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.NotNull(matches);
            Assert.Equal(2, matches.Length);

            Assert.Equal(0, matches[0].Start);
            Assert.Equal(toFind.Length, matches[0].Length);

            Assert.Equal(10, matches[1].Start);
            Assert.Equal(toFind.Length, matches[1].Length);
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void MultipleMatchesLeadingMiddleTrailing(IStringSearchAlgorithm algorithm)
        {
            string toFind = "found";
            string toSearch = "leadingfound and foundtrailing";

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.NotNull(matches);
            Assert.Equal(2, matches.Length);

            Assert.Equal(7, matches[0].Start);
            Assert.Equal(toFind.Length, matches[0].Length);

            Assert.Equal(17, matches[1].Start);
            Assert.Equal(toFind.Length, matches[1].Length);
        }

        [Theory]
        [ClassData(typeof(SearchAlgorithms))]
        public void MatchesMoveToEndOfMatch(IStringSearchAlgorithm algorithm)
        {
            string toFind = "aa";
            string toSearch = "aaaaaa";

            ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.NotNull(matches);
            Assert.Equal(3, matches.Length);
        }
    }
}
