using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OfficeSuppliersLinkSoft.Data.Infrastructure;
using OfficeSuppliersLinkSoft.Data.Repositories;
using OfficeSuppliersLinkSoft.Model;
using OfficeSuppliersLinkSoft.Service;
using OfficeSuppliersLinkSoft.Web.Controllers;
using OfficeSuppliersLinkSoft.Web.Mappings;
using OfficeSuppliersLinkSoft.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using TestStack.FluentMVCTesting;

namespace OfficeSuppliersLinkSoft.Test.Unit
{
    /// <summary>
    /// SupplierController testing class
    /// </summary>
    [TestClass]
    public class SupplierControllerTest
    {
        /// <summary>
        /// Controller's instance
        /// </summary>
        SupplierController _controller;

        /// <summary>
        /// Supplier's list. will be initialized
        /// in TestInitialize method and used across
        /// this testing class
        /// </summary>
        List<Supplier> _suppliers;

        /// <summary>
        /// Supplier's object will be used for
        /// HTTP POST testign
        /// </summary>
        Supplier _newSupplier;

        /// <summary>
        /// Initialize method.
        /// Do mocking a data initialization
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            AutoMapperConfiguration.Configure();

            _newSupplier = new Supplier
            {
                SupplierId = 2,
                Name = "Test 2",
                Address = "Test address 2",
                EmailAddress = "TestEmail@test2.com",
                Telephone = 123456789,
                Groups = new List<Group>
                {
                    new Group
                    {
                        GroupId = 1,
                        Name = "Test 1"
                    }
                }
            };

            _suppliers = new List<Supplier>
            {
                new Supplier
                {
                    SupplierId = 1,
                    Name = "Test 1",
                    Address = "Test address 1",
                    EmailAddress = "TestEmail@test1.com",
                    Telephone = 987654321,
                    Groups = new List<Group>
                    {
                        new Group
                        {
                            GroupId = 1,
                            Name = "Test 1"
                        }
                    }
                }
            };
            // mocking services which are neccessary to initialize
            // SupplierController
            var mockedSupplier = new Mock<ISupplierService>();
            mockedSupplier.Setup(x => x.GetSuppliers()).Returns(_suppliers);
            mockedSupplier.Setup(x => x.GetSupplier(1)).Returns(_suppliers.First(s => s.SupplierId == 1));
            mockedSupplier.Setup(x => x.UpdateSupplier(_newSupplier));

            var mockedGroup = new Mock<IGroupService>();
            // initialize controllers with mocked services
            _controller = new SupplierController(mockedSupplier.Object, mockedGroup.Object);
        }

        /// <summary>
        /// Test controller's View rendering of Index()
        /// and testing suppliers service GetSuppliers() method
        /// Should return non zero result in ViewModel
        /// </summary>
        [TestMethod]
        public void Index()
        {
            _controller.WithCallTo(s => s.Index())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<Supplier>>(s => s.Count() > 0);
        }

        /// <summary>
        /// Testing controller's View rendering of Details()
        /// and we are looking for supplier with SupplierId == 1
        /// This supplier should by loaded to the ViewModel
        /// </summary>
        [TestMethod]
        public void Details()
        {
            _controller.WithCallTo(s => s.Details(1))
                .ShouldRenderDefaultView()
                .WithModel<Supplier>(s => s == _suppliers.First(x => x.SupplierId == 1));
        }

        /// <summary>
        /// Testing controller's View rendering of Create()
        /// </summary>
        [TestMethod]
        public void CreateHttpGet()
        {
            _controller.WithCallTo(s => s.Create())
                .ShouldRenderDefaultView();
        }

        /// <summary>
        /// Testing controller's View rendering of Edit(int? id)
        /// and this method should load supplier with SupplierId == 1
        /// This model should be loaded to the Edit(int? id)
        /// </summary>
        [TestMethod]
        public void EditHttpGet()
        {
            _controller.WithCallTo(s => s.Edit(1))
                .ShouldRenderDefaultView()
                .WithModel<Supplier>(s => s == _suppliers.First(x => x.SupplierId == 1));
        }

        /// <summary>
        /// Testing controller's View rendering of Delete(int? id)
        /// and this method sould load supplier with SupplierId == 1
        /// This Model should be loaded to the Delete(int? id)
        /// </summary>
        [TestMethod]
        public void DeleteHttpGet()
        {
            _controller.WithCallTo(s => s.Delete(1))
                .ShouldRenderDefaultView()
                .WithModel<Supplier>(s => s == _suppliers.First(x => x.SupplierId == 1));
        }

        /// <summary>
        /// Testing adding new Supplier to the supplier's collection
        /// and redirecting to the Index() view
        /// </summary>
        [TestMethod]
        public void CreateHttpPost()
        {
            _controller.WithCallTo(s => s
                .Create(new SupplierViewModel { SupplierId = 2, Name = "Test 2" }, new int[] { 1 }))
                .ShouldRedirectTo(s => s.Index());
        }

        /// <summary>
        /// Testing mark Supplier as edited
        /// and redirecting to the Index() view
        /// </summary>
        [TestMethod]
        public void EditHttpPost()
        {
            // need to do some more Mock because of TryUpdateModel function
            // used in Edit(SupplierViewModel model, int[] ids)
            var request = new Mock<HttpRequestBase>();
            request.Setup(r => r.HttpMethod).Returns("POST");
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(c => c.Request).Returns(request.Object);
            // set up COntrollerContext for mocked controller because of
            // data changing through TryUpdateModel
            var controllerContext = new ControllerContext(
                mockHttpContext.Object, 
                new RouteData(), 
                new Mock<ControllerBase>().Object);
            _controller.ControllerContext = controllerContext;
            
            // create fake form values
            // they will be used for SupplierViewModel changing
            var fakeForm = new FormCollection();
            fakeForm.Add("Name", "Test 3");
            fakeForm.Add("Address", "New address");
            fakeForm.Add("EmailAddress", "NewEmal@test.com");
            fakeForm.Add("Telephone", "312456879");
            // change ValueProvider to fake one
            _controller.ValueProvider = fakeForm.ToValueProvider();

            _controller.WithCallTo(g => g
                .Edit(new SupplierViewModel
                        {
                            SupplierId = 1,
                            Name = "Test 1",
                            Address = "Test 1",
                            EmailAddress = "Test@test.com",
                            Telephone = 987456321
                        }, 
                        new int[] { 1 }))
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
                .DeleteConfirmed(new SupplierViewModel { SupplierId = 2, Name = "Test 2" }))
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
