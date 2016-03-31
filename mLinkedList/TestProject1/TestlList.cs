using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LList2_2;

namespace TestProject1
{
    //[TestFixture(typeof(AList0))]
    //[TestFixture(typeof(AList1))]
    //[TestFixture(typeof(AList2))]
    //[TestFixture(typeof(LList1))]
    [TestFixture(typeof(LList1x))]
    //[TestFixture(typeof(LList2))]

    public class TestIList<TList> where TList : IList, new()
    {
        //IList xList = new AList0();
        //IList xList = new AList1();
        //IList xList = new AList2();
        //IList xList = new LList1();
        //IList xList = new LList1x();

        IList xList = new TList();

        [SetUp]
        public void SetUp()
        {
            xList.clear();
        }


        #region size-clear-toArray-get-set_Tests

        #region init-sizeTests

        [Test]
        [TestCase(null, 0)]
        [TestCase(new int[0], 0)]
        [TestCase(new int[] { 7 }, 1)]
        [TestCase(new int[] { 0, 2 }, 2)]
        [TestCase(new int[] { 0, 2, 3, 4, 1 }, 5)]
        public void initSizeTest(int[] ini, int exp)
        {
            xList.init(ini);
            int act = xList.size();
            Assert.AreEqual(exp, act);
        }
        #endregion
        #region init-clearTests

        [Test]
        [TestCase(null, 0)]
        [TestCase(new int[0], 0)]
        [TestCase(new int[] { 9 }, 0)]
        [TestCase(new int[] { 2, 4 }, 0)]
        [TestCase(new int[] { 2, 4, 8, 0, 9 }, 0)]
        public void initClearTest(int[] ini, int exp)
        {
            xList.init(ini);
            xList.clear();
            int res = xList.size();
            Assert.AreEqual(exp, res);
        }

        #endregion

        #region init-toArrayTests

        [Test]
        [TestCase(null, new int[0])]
        [TestCase(new int[0], new int[0])]
        [TestCase(new int[] { 5 }, new int[] { 5 })]
        [TestCase(new int[] { 1, 3 }, new int[] { 1, 3 })]
        [TestCase(new int[] { 0, 2, 3, 1, 4 }, new int[] { 0, 2, 3, 1, 4 })]
        public void initToArrayTest(int[] ini, int[] exp)
        {
            xList.init(ini);
            int[] act = xList.toArray();
            Assert.AreEqual(exp, act);
        }

        #endregion

        #region init-getTests

        [Test]
        [TestCase(new int[] { 1 }, 0, 1)]
        [TestCase(new int[] { 5, 3 }, 1, 3)]
        [TestCase(new int[] { 3, 2, 5, 4, 6, 8 }, 3, 4)]
        public void initGetTest(int[] ini, int pos, int exp)
        {
            xList.init(ini);
            int act = xList.get(pos);
            Assert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(null, 0)]
        [TestCase(new int[0], 0)]
        [TestCase(new int[] { 1, 3 }, -1)]
        [TestCase(new int[] { 0, 2 }, 2)]
        public void initGet_Ex(int[] ini, int pos)
        {
            xList.init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => xList.get(pos));
        }

        #endregion

        #region init-setTests

        [Test]
        [TestCase(new int[] { 5 }, 0, 1, new int[] { 1 })]
        [TestCase(new int[] { 2, 3 }, 1, 1, new int[] { 2, 1 })]
        [TestCase(new int[] { 1, 3, 4, 5, 0 }, 2, 5, new int[] { 1, 3, 5, 5, 0 })]
        public void initSetTests(int[] ini, int pos, int val, int[] expAr)
        {
            xList.init(ini);
            xList.set(pos, val);
            int[] actAr = xList.toArray();
            Assert.AreEqual(expAr, actAr);
        }

        [Test]
        [TestCase(null, 0, 1)]
        [TestCase(new int[0], 0, 2)]
        public void initSet_Ex(int[] ini, int pos, int val)
        {
            xList.init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => xList.set(pos, val));
        }

        #endregion

        #endregion

        #region addStart-addEnd-addPos_Tests

        #region addStartTests

        [Test]
        [TestCase(null, 3, 1, new int[] { 3 })]
        [TestCase(new int[0], 8, 1, new int[] { 8 })]
        [TestCase(new int[] { 1 }, 2, 2, new int[] { 2, 1 })]
        [TestCase(new int[] { 3, 0 }, 1, 3, new int[] { 1, 3, 0 })]
        [TestCase(new int[] { 2, 3, 4, 8, 9 }, 5, 6, new int[] { 5, 2, 3, 4, 8, 9 })]
        public void addStartTest(int[] ini, int val, int expL, int[] expAr)
        {
            xList.init(ini);
            xList.addStart(val);

            int actL = xList.size();
            Assert.AreEqual(expL, actL);

            int[] actAr = xList.toArray();
            Assert.AreEqual(expAr, actAr);

        }

        #endregion

        #region addEndTest

        [Test]
        [TestCase(null, 2, 1, new int[] { 2 })]
        [TestCase(new int[0], 6, 1, new int[] { 6 })]
        [TestCase(new int[] { 5 }, 1, 2, new int[] { 5, 1 })]
        [TestCase(new int[] { 2, 0 }, 3, 3, new int[] { 2, 0, 3 })]
        [TestCase(new int[] { 1, 3, 4, 0, 5 }, 7, 6, new int[] { 1, 3, 4, 0, 5, 7 })]
        public void addEndTest(int[] ini, int val, int expL, int[] expAr)
        {
            xList.init(ini);
            xList.addEnd(val);

            int actL = xList.size();
            Assert.AreEqual(expL, actL);

            int[] actAr = xList.toArray();
            Assert.AreEqual(expAr, actAr);
        }
        #endregion

        #region addPosTest

        [Test]
        [TestCase(null, 0, 2, new int[] { 2 })]
        [TestCase(new int[0], 0, 1, new int[] { 1 })]
        [TestCase(new int[] { 1 }, 0, 2, new int[] { 2, 1 })]
        [TestCase(new int[] { 3, 2 }, 1, 0, new int[] { 3, 0, 2 })]
        [TestCase(new int[] { 3, 4, 7, 2, 1 }, 2, 5, new int[] { 3, 4, 5, 7, 2, 1 })]
        [TestCase(new int[] { 3, 4, 7, 2, 1 }, 0, 5, new int[] { 5, 3, 4, 7, 2, 1 })]
        [TestCase(new int[] { 2, 3, 1 }, 3, 2, new int[] { 2, 3, 1, 2 })]
        public void addPosTest(int[] ini, int pos, int val, int[] expAr)
        {
            xList.init(ini);
            xList.addPos(pos, val);

            int[] actAr = xList.toArray();
            Assert.AreEqual(expAr, actAr);

        }

        [Test]
        [TestCase(new int[] { 2, 3, 1 }, -1, 2)]
        [TestCase(new int[] { 2, 3, 1 }, 4, 2)]
        public void addPos_Ex(int[] ini, int pos, int val)
        {
            xList.init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => xList.addPos(pos, val));
        }

        #endregion

        #endregion

        #region delStart-delEnd-delPos_Tests

        #region delStartTest

        [Test]
        [TestCase(new int[] { 6 }, 6)]
        [TestCase(new int[] { 4, 2 }, 4)]
        [TestCase(new int[] { 2, 3, 1, 0, 5, 6 }, 2)]
        public void delStartTest(int[] ini, int expR)
        {
            xList.init(ini);
            int actR = xList.delStart();
            Assert.AreEqual(expR, actR);




        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[0])]
        public void delEnd_Ex(int[] ini)
        {
            xList.init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => xList.delEnd());
        }

        #endregion

        #region delEndTest

        [Test]
        [TestCase(new int[] { 6 }, 6)]
        [TestCase(new int[] { 4, 2 }, 2)]
        [TestCase(new int[] { 2, 3, 1, 0, 5, 6 }, 6)]
        public void delEndTest(int[] ini, int expR)
        {
            xList.init(ini);
            int actR = xList.delEnd();
            Assert.AreEqual(expR, actR);


        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[0])]
        public void delStart_Ex(int[] ini)
        {
            xList.init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => xList.delStart());
        }

        #endregion

        #region delPosTest
        [Test]
        [TestCase(new int[] { 2 }, 0, 2)]
        [TestCase(new int[] { 5, 1 }, 1, 1)]
        [TestCase(new int[] { 6, 3, 2, 1 }, 3, 1)]
        public void delPosTest(int[] ini, int pos, int expD)
        {
            xList.init(ini);
            int actD = xList.delPos(pos);
            Assert.AreEqual(expD, actD);
        }

        [Test]
        [TestCase(null, 0)]
        [TestCase(new int[0], 0)]
        [TestCase(new int[] { 3, 6 }, -1)]
        [TestCase(new int[] { 2, 3, 5 }, 3)]
        public void delPos_Ex(int[] ini, int pos)
        {
            xList.init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => xList.delPos(pos));
        }

        #endregion

        #endregion

        #region min-max-minIndex-maxIndex-reverse-halfRevers-sort_Tests

        #region minTest

        [Test]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { -1, 3 }, -1)]
        [TestCase(new int[] { 1, 0, 3, 4, 8, 2 }, 0)]
        public void minTest(int[] ini, int exp)
        {
            xList.init(ini);
            int act = xList.min();
            Assert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[0])]
        public void minTest(int[] ini)
        {
            xList.init(ini);
            Assert.Throws<IndexOutOfRangeException>(() => xList.min());
        }

        #endregion

        #region maxTest

        [Test]
        [TestCase(new int[] { -2 }, -2)]
        [TestCase(new int[] { 3, 0 }, 3)]
        [TestCase(new int[] { 1, 0, 3, 4, 8, 2 }, 8)]
        public void maxTest(int[] ini, int exp)
        {
            xList.init(ini);
            int act = xList.max();
            Assert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[0])]
        public void max_Ex(int[] ini)
        {
            xList.init(ini);
            Assert.Throws<NullReferenceException>(() => xList.max());
        }

        #endregion

        #region minIndexTest

        [Test]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 5, 9 }, 0)]
        [TestCase(new int[] { 3, 2, 4, 7, 1, 6 }, 4)]
        public void minIndexTest(int[] ini, int exp)
        {
            xList.init(ini);
            int act = xList.minIndex();
            Assert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[0])]
        public void minIndex_Ex(int[] ini)
        {
            xList.init(ini);
            Assert.Throws<InvalidOperationException>(() => xList.minIndex());
        }

        #endregion

        #region maxIndexTest

        [Test]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 5, 9 }, 1)]
        [TestCase(new int[] { 3, 2, 4, 7, 1, 6 }, 3)]
        public void maxIndexTest(int[] ini, int exp)
        {
            xList.init(ini);
            int act = xList.maxIndex();
            Assert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[0])]
        public void maxIndex_Ex(int[] ini)
        {
            xList.init(ini);
            Assert.Throws<InvalidOperationException>(() => xList.minIndex());
        }

        #endregion

        #region reverseTests

        [Test]
        [TestCase(null, new int[0])]
        [TestCase(new int[0], new int[0])]
        [TestCase(new int[] { 7 }, new int[] { 7 })]
        [TestCase(new int[] { 4, -1 }, new int[] { -1, 4 })]
        [TestCase(new int[] { 3, 2, 0, 1, 7 }, new int[] { 7, 1, 0, 2, 3 })]
        public void reverseTest(int[] ini, int[] expAr)
        {
            xList.init(ini);
            xList.reverse();
            int[] actAr = xList.toArray();
            Assert.AreEqual(expAr, actAr);

        }

        #endregion

        #region halfReversTest

        [Test]
        [TestCase(new int[] { 6 }, new int[] { 6 })]
        [TestCase(new int[] { 2, 8 }, new int[] { 8, 2 })]
        [TestCase(new int[] { 4, 3, 0, 2, 1 }, new int[] { 2, 1, 0, 4, 3 })]
        [TestCase(new int[] { 2, 3, 1, 0, 3, 4 }, new int[] { 0, 3, 4, 2, 3, 1 })]
        public void halfReversTest(int[] ini, int[] expAr)
        {
            xList.init(ini);
            xList.halfRevers();
            int[] actAr = xList.toArray();
            Assert.AreEqual(expAr, actAr);
        }


        #endregion

        #region sortTest

        [Test]
        // [TestCase(null, new int[0])]
        //[TestCase(new int[0], new int[0])]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 3, 0 }, new int[] { 0, 3 })]
        [TestCase(new int[] { 3, 4, 8, 1, 0, 2 }, new int[] { 0, 1, 2, 3, 4, 8 })]
        public void sortTest(int[] ini, int[] expAr)
        {
            xList.init(ini);
            xList.sort();
            int[] actAr = xList.toArray();
            Assert.AreEqual(expAr, actAr);
        }
        [Test]
        [TestCase(null, new int[0])]
        [TestCase(new int[0], new int[0])]
        public void sortTest_Ex(int[] ini, int[] expAr)
        {
            xList.init(ini);
            Assert.Throws<NullReferenceException>(() => xList.sort());
        }
        #endregion


        #endregion
    }
}
