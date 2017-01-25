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

namespace OfficeSuppliersLinkSoft.Test.Unit
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
        /// Test controller's View rendering of Index()
        /// and testing group's service GetGroups() method
        /// Should return non zero result in ViewModel
        /// </summary>
        [TestMethod]
        public void Index()
        {
            _controller.WithCallTo(g => g.Index())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<Group>>(g => g.Count() > 0);
        }

        /// <summary>
        /// Testing controller's View rendering of Details()
        /// and we are  looking for group with GroupId == 1
        /// This group should be loaded to the ViewModel
        /// </summary>
        [TestMethod]
        public void Details()
        {
            _controller.WithCallTo(g => g.Details(1))
                .ShouldRenderDefaultView()
                .WithModel<Group>(g => g == _groups.First(x => x.GroupId == 1));
        }

        /// <summary>
        /// Testing controller's View rendering of Create()
        /// </summary>
        [TestMethod]
        public void CreateHttpGet()
        {
            _controller.WithCallTo(g => g.Create())
                .ShouldRenderDefaultView();
        }

        /// <summary>
        /// Testing controller's View rendering of Edit(int? id)
        /// and this method should load group with GroupId == 1
        /// This Model should be loaded to the Edit(int? id)
        /// </summary>
        [TestMethod]
        public void EditHttpGet()
        {
            _controller.WithCallTo(g => g.Edit(1))
                .ShouldRenderDefaultView()
                .WithModel<Group>(g => g == _groups.First(x => x.GroupId == 1));
        }

        /// <summary>
        /// Testing controller's View rendering of Delete(int? id)
        /// and this method sould load group with GroupId == 1
        /// This Model should be loaded to the Delete(int? id)
        /// </summary>
        [TestMethod]
        public void DeleteHttpGet()
        {
            _controller.WithCallTo(g => g.Delete(1))
                .ShouldRenderDefaultView()
                .WithModel<Group>(g => g == _groups.First(x => x.GroupId == 1));
        }

        /// <summary>
        /// Testing adding new Group to the group's collection
        /// and redirecting to the Index() view
        /// </summary>
        [TestMethod]
        public void CreateHttpPost()
        {
            _controller.WithCallTo(g => g
                .Create(new GroupViewModel { GroupId = 2, Name = "Test 2" }))
                .ShouldRedirectTo(g => g.Index());
        }

        /// <summary>
        /// Testing mark Group as edited
        /// and redirecting to the Index() view
        /// </summary>
        [TestMethod]
        public void EditHttpPost()
        {
            _controller.WithCallTo(g => g
                .Edit(new GroupViewModel { GroupId = 2, Name = "Test 2" }))
                .ShouldRedirectTo(g => g.Index());
        }

        /// <summary>
        /// Testing mark group as deleted
        /// and redirecting to the Index() view
        /// </summary>
        [TestMethod]
        public void DeleteHttpPost()
        {
            _controller.WithCallTo(g => g
                .DeleteConfirmed(new GroupViewModel { GroupId = 2, Name = "Test 2" }))
                .ShouldRedirectTo(g => g.Index());
        }

        /// <summary>
        /// Clean when every test is finished
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            if (_controller != null)
                _controller.Dispose();
        }
    }
}
