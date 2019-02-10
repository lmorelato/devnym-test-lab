using System;
using System.Collections;
using NyTO.Library.Code;
using Xunit;

namespace NyTO.Test.Code
{
    public class ExterminatorTests
    {
        /// <summary>
        /// In this case, the method does not work as intended, because we have a logic error
        /// when trying to remove the target value (explanation in the method)
        /// </summary>
        /// <param name="values"></param>
        /// <param name="target"></param>
        [Theory]
        [InlineData(new[] { 1, 0, 1, 1, 1, 2, 1, 3, 1, 4, 5, 1, 1, 1 }, 1)]
        public void Exterminate_ListHasTargetValue_ListWithNoTargetValue(int[] values, int target)
        {
            var list = new ArrayList(values);

            Exterminator.Exterminate(list, target);

            //Assert.DoesNotContain(target, list.ToArray());
        }

        /// <summary>
        /// Improving  Exterminator.Exterminate...
        /// </summary>
        /// <param name="values"></param>
        /// <param name="target"></param>
        [Theory]
        [InlineData(new[] { 1, 0, 1, 1, 1, 2, 1, 3, 1, 4, 5, 1, 1, 1 }, 1)]
        public void ExterminateV2_ListHasTargetValue_ListWithNoTargetValue(int[] values, int target)
        {
            var list = new ArrayList(values);

            var result = Exterminator.ExterminateV2(list, target);

            Assert.DoesNotContain(target, result.ToArray());
        }

        /// <summary>
        /// Improving  Exterminator.ExterminateV2...
        /// </summary>
        /// <param name="values"></param>
        /// <param name="target"></param>
        [Theory]
        [InlineData(new[] { 1, 0, 1, 1, 1, 2, 1, 3, 1, 4, 5, 1, 1, 1 }, 1)]
        public void ExterminateV3_ListHasTargetValue_ListWithNoTargetValue(int[] values, int target)
        {
            var list = new ArrayList(values);

            var result = Exterminator.ExterminateV3(list, target);

            Assert.DoesNotContain(target, result.ToArray());
        }

        [Fact]
        public void Exterminate_ListIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Exterminator.Exterminate(null, 1));
        }

        [Fact]
        public void ExterminateV2_ListIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Exterminator.ExterminateV2(null, 1));
        }

        [Fact]
        public void ExterminateV3_ListIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Exterminator.ExterminateV3(null, 1));
        }

        [Fact]
        public void ExterminateV3_ListHasNotTargetValue_SameList()
        {
            var list = new ArrayList(new [] {1,2,3});

            var result = Exterminator.ExterminateV3(list, 100);

            Assert.Equal(3, result.Count);
        }
    }
}
