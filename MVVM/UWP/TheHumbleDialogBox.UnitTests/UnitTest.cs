using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheHumbleDialogBox.Core.ViewModel;

namespace TheHumbleDialogBox.UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void NameOk()
        {
            var mainPage = new MainPageViewModel();
            mainPage.Name = "John Smith";
            mainPage.Ssn = "123-45-6782";

            var result = mainPage.OnOk();

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void BlankOk()
        {
            var mainPage = new MainPageViewModel();
            mainPage.Name = "John Smith";
            mainPage.Ssn = "123-45-678";

            var result = mainPage.OnOk();

            mainPage.Name = "John Smith";
            mainPage.Ssn = "123-45-6782";

            result = mainPage.OnOk();

            Assert.AreEqual(string.Empty, mainPage.ErrorMessage);
        }

        [TestMethod]
        public void BadName()
        {
            var mainPage = new MainPageViewModel();
            mainPage.Name = "";
            mainPage.Ssn = "123-45-6782";

            var result = mainPage.OnOk();

            Assert.AreEqual(mainPage.ErrorMessage, "Bad name.");
        }

        [TestMethod]
        public void BadSsn()
        {
            var mainPage = new MainPageViewModel();
            mainPage.Name = "John Smith";
            mainPage.Ssn = "";

            var result = mainPage.OnOk();

            Assert.AreEqual(mainPage.ErrorMessage, "Bad SSN.");
        }
    }
}
