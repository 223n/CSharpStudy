using csharp_study;
using System.Diagnostics;

namespace csharp_study_test
{
    [TestClass]
    public class TItemClass
    {

        [TestMethod]
        public void ItemClassInitializeTest()
        {

            var itemA = new ItemClass();
            Assert.IsNotNull(itemA);

            var itemB = new ItemClass(itemA);
            Assert.IsNotNull(itemB);

            var itemC = new ItemClass((IItem)itemA);
            Assert.IsNotNull(itemC);

            var itemD = new ItemClass("itemD");
            Assert.IsNotNull(itemD);

            var itemE = new ItemClass("itemE", 0);
            Assert.IsNotNull(itemE);

            var itemF = new ItemClass("itemF", 0, null);
            Assert.IsNotNull(itemF);

        }

        [TestMethod]
        public void CountUnderTest()
        {
            try
            {
                using (var item = new ItemClass("item", -1, null)) { }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Debug.Assert(true, ex.Message);
            }
            catch (Exception ex) 
            { 
                Assert.Fail(ex.ToString());
            }
        }

    }
}
