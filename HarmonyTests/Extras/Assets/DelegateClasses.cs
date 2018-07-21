namespace HarmonyTests.Extras.Assets
{
   public class TestPrivateDelegateClass
   {
		private delegate string TestDelegate();

		private string TestDelegateMethod(string unused1, TestDelegate testDelegate, string unused2, string unused3)
		{
			return testDelegate();
		}
   }
}
