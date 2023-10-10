namespace ALight.NLog.LayoutRenderer.Hash.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSHA256EmptyString()
        {
            var retVal = HashHelper.HashSHA256(String.Empty);
            Assert.AreEqual(string.Empty, retVal);
        }

        [Test]
        public void TestSHA256Null()
        {
            var retVal = HashHelper.HashSHA256(null);
            Assert.AreEqual(string.Empty, retVal);
        }

        [Test]
        public void TestSHA256NonEmptyString()
        {
            var retVal = HashHelper.HashSHA256("A");
            Assert.AreNotEqual(string.Empty, retVal);
        }

        [Test]
        public void TestMurmurEmptyString()
        {
            var retVal = HashHelper.HashMurmur(String.Empty);
            Assert.AreEqual(string.Empty, retVal);
        }

        [Test]
        public void TestMurmurNull()
        {
            var retVal = HashHelper.HashMurmur(null);
            Assert.AreEqual(string.Empty, retVal);
        }

        [Test]
        public void TestMurmurNonEmptyString()
        {
            var retVal = HashHelper.HashMurmur("A");
            Assert.AreNotEqual(string.Empty, retVal);
        }
    }
}