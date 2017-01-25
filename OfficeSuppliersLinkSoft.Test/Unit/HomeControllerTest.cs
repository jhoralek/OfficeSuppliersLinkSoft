using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeSuppliersLinkSoft.Web.Controllers;
using TestStack.FluentMVCTesting;

namespace OfficeSuppliersLinkSoft.Test.Unit
{
    [TestClass]
    public class HomeControllerTest
    {
        HomeController _controller;

        /// <summary>
        /// Initialize test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _controller = new HomeController();
        }

        /// <summary>
        /// Test if Index() retrives DefaultView without any ModelView
        /// </summary>
        [TestMethod]
        public void Index()
        {
            _controller.WithCallTo(h => h.Index()).ShouldRenderDefaultView();
        }

        /// <summary>
        /// Release controller instance
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            if (_controller != null)
                _controller.Dispose();
        }
    }
}
