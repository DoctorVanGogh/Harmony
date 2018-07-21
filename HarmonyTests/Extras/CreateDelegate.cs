using Harmony;
using Harmony.Extras;
using HarmonyTests.Extras.Assets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarmonyTests.Extras
{
   [TestClass]
   class CreateDelegate
   {
		[TestMethod]
		public void TestDelegate()
		{
			var type = typeof(TestPrivateDelegateClass);
			Assert.IsNotNull(type);
			var method = AccessTools.Method(type, "TestDelegateMethod");
			Assert.IsNotNull(method);

			var delegateMethod = AccessTools.Method(typeof(CreateDelegate), "TestDelegateMethod");
			Assert.IsNotNull(delegateMethod);

			var createdDelegate = ClosureDelegateGenerator.CreateDelegate(method, "testDelegate", delegateMethod);
			Assert.IsNotNull(createdDelegate);

			var testMethod = AccessTools.Method(type, "TestDelegateMethod");
			Assert.IsNotNull(testMethod);

			var testInstance = new TestPrivateDelegateClass();
			Assert.IsNotNull(testInstance);

			var returnedDelegateValue = testMethod.Invoke(testInstance, new object[] { null, createdDelegate, null, null });
			Assert.IsNotNull(returnedDelegateValue);

			Assert.AreEqual(returnedDelegateValue, TestDelegateMethod());

			/*Assert.AreEqual(args[0], 1);
			Assert.AreEqual(args[1], 1);
			Assert.AreEqual(args[2], 2);*/
		}

		public static string TestDelegateMethod()
		{
			return "TestDelegateValue";
		}
   }
}
