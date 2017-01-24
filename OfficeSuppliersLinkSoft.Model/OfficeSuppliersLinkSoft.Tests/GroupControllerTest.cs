using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OfficeSuppliersLinkSoft.Model;
using OfficeSuppliersLinkSoft.Service;
using OfficeSuppliersLinkSoft.Web.Controllers;
using OfficeSuppliersLinkSoft.Web.Mappings;
using OfficeSuppliersLinkSoft.Web.Models;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace OfficeSuppliersLinkSoft.Tests
{
    /// <summary>
    /// Testing Grup controller functions
    /// </summary>
    [TestClass]
    public class GroupControllerTest
    {
        GroupController _controller;
        List<Group> _groups;
        Group _newGroup;

        /// <summary>
        /// Prepare Mock service for testing our controllers
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            AutoMapperConfiguration.Configure();

            _newGroup = new Group { GroupId = 2, Name = "Test 2" };
            _groups = new List<Group>
                         {
                            new Group { GroupId = 1, Name = "Test" }
                         };

            var mockService = new Mock<IGroupService>();
            // setup GetGroups list 
            mockService.Setup(x => x.GetGroups()).Returns(_groups);
            mockService.Setup(x => x.GetGroup(1)).Returns(_groups.First(g => g.GroupId == 1));
            mockService.Setup(x => x.CreateGroup(_newGroup));

            // initialize controller
            _controller = new GroupController(mockService.Object);
        }

        /// <summary>
        /// Test calling Index View with correct model
        /// </summary>
        [TestMethod]
        public void Index()
        {
            _controller.WithCallTo(g => g.Index())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<Group>>();
        }

        /// <summary>
        /// Retrive instance of Group Model with
        /// Name "Test"
        /// </summary>
        [TestMethod]
        public void Details()
        {
            _controller.WithCallTo(g => g.Details(1))
                .ShouldRenderDefaultView()
                .WithModel<Group>(g => g == _groups.First(x => x.GroupId == 1));
        }

        [TestMethod]
        public void CreateHttpGet()
        {
            _controller.WithCallTo(g => g.Create())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void EditHttpGet()
        {
            _controller.WithCallTo(g => g.Edit(1))
                .ShouldRenderDefaultView()
                .WithModel<Group>(g => g == _groups.First(x => x.GroupId == 1));
        }

        [TestMethod]
        public void DeleteHttpGet()
        {
            _controller.WithCallTo(g => g.Delete(1))
                .ShouldRenderDefaultView()
                .WithModel<Group>(g => g == _groups.First(x => x.GroupId == 1));
        }

        [TestMethod]
        public void CreateHttpPost()
        {
            _controller.WithCallTo(g => g.Create(new GroupViewModel { GroupId = 2, Name = "Test 2" }))
                .ShouldRedirectTo(g => g.Index());

        }

        [TestMethod]
        public void EditHttpPost()
        {
            _controller.WithCallTo(g => g.Edit(new GroupViewModel { GroupId = 2, Name = "Test 2" }))
                .ShouldRedirectTo(g => g.Index());

        }

        [TestMethod]
        public void DeleteHttpPost()
        {
            _controller.WithCallTo(g => g.DeleteConfirmed(new GroupViewModel { GroupId = 2, Name = "Test 2" }))
                .ShouldRedirectTo(g => g.Index());

        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_controller != null)
                _controller.Dispose();
        }
    }
}
