using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace WebRouting.UnitTest
{
    [TestClass]
    public class ProductControllerRouteTest
    {
        [TestMethod]
        public void ProductGetRouteTest()
        {
            // Setup
            var productRepositoryMock = new ProductRepositoryMock();
            RouteHelper testHelper = RouteHelper.Create();
            testHelper.Resolver.RegisterInstance<IProductRepository>(productRepositoryMock);

            // Action
            var products = testHelper.Get("api/product");

            // Assertion
            Assert.IsTrue(productRepositoryMock.RetrieveProductsCalled);
        }
    }


    public class ProductRepositoryMock : IProductRepository
    {
        public bool RetrieveProductsCalled { get; private set; }
        public List<Product> RetrieveProducts()
        {
            RetrieveProductsCalled = true;
            return new List<Product>();
        }
    }
}
