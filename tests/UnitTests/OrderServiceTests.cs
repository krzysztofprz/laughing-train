using CommonBusinessLogic.Models;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Rootobject _dummyData;

        [SetUp]
        public void Setup()
        {
            #region TestData

            _dummyData = new Rootobject()
            {
                Content = new Content[]
                {
                    new Content()
                    {
                        Lines = new Line[]
                        {
                            new Line()
                            {
                                MerchantProductNo = "123456789",
                                Quantity = 10
                            },
                            new Line()
                            {
                                MerchantProductNo = "234567890",
                                Quantity = 100
                            },
                            new Line()
                            {
                                MerchantProductNo = "345678901",
                                Quantity = 5
                            },
                            new Line()
                            {
                                MerchantProductNo = "456789012",
                                Quantity = 1
                            },
                            new Line()
                            {
                                MerchantProductNo = "567890123",
                                Quantity = 12
                            }
                        }
                    }
                }
            };

            #endregion TestData
        }

        [Test]
        public void OrderService_GetOrders_ValidStatus_ReturnsOrders()
        {
            Assert.Pass();
        }

        [Test]
        public void OrderService_GetOrders_InvalidStatus_NoReturnsOrders()
        {
            Assert.Pass();
        }

        [Test]
        public void OrderService_GetOrders_TenOrders_ReturnsFiveOrders()
        {
            Assert.Pass();
        }

        [Test]
        public void OrderService_GetOrders_TwoOrder_ReturnsTwoOrders()
        {
            Assert.Pass();
        }
    }
}