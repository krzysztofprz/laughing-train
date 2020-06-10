using CommonBusinessLogic.Dictionary;
using CommonBusinessLogic.Interfaces;
using CommonBusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Controllers;

namespace UnitTests
{
    public class ProductControllerTests
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
                                Quantity = 3
                            },
                            new Line()
                            {
                                MerchantProductNo = "678901234",
                                Quantity = 30
                            },
                            new Line()
                            {
                                MerchantProductNo = "789012345",
                                Quantity = 31
                            },
                            new Line()
                            {
                                MerchantProductNo = "890123456",
                                Quantity = 6
                            },
                            new Line()
                            {
                                MerchantProductNo = "901234567",
                                Quantity = 12
                            },
                            new Line()
                            {
                                MerchantProductNo = "012345678",
                                Quantity = 12
                            }
                        },
                        Status = Status.IN_PROGRESS.ToString()
                    }
                }
            };

            #endregion TestData
        }

        [Test]
        public async Task ProductController_IndexAsync_ValidStatus_ReturnsOrdersAsync()
        {
            // Arrange    
            var inProgressData = _dummyData.Content
                .Where(x => x.Status == Status.IN_PROGRESS.ToString())
                .ToList();

            var orderServiceMock = new Mock<IOrderService>();
            orderServiceMock.Setup(x => x.GetOrders(Status.IN_PROGRESS))
                .ReturnsAsync(inProgressData);

            var orderService = orderServiceMock.Object;

            var productController = new ProductController(orderService);

            // Act
            var result = await productController.IndexAsync() as ViewResult;
            var modelResult = result.ViewData.Model as IEnumerable<Line>;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(modelResult.ToList().Count(), Is.EqualTo(5));
            Assert.That(modelResult.ToList().ElementAt(0).Quantity, Is.EqualTo(100));
            Assert.That(modelResult.ToList().ElementAt(4).Quantity, Is.EqualTo(12));
        }

        [Test]
        public async Task ProductController_IndexAsync_InvalidStatus_NoReturnsOrders()
        {
            // Arrange       
            Status dummyStatus = (Status)99;

            var dummyStatusData = _dummyData.Content
                .Where(x => x.Status == dummyStatus.ToString())
                .ToList();

            var orderServiceMock = new Mock<IOrderService>();
            orderServiceMock.Setup(x => x.GetOrders(dummyStatus))
                .ReturnsAsync(dummyStatusData);

            var orderService = orderServiceMock.Object;

            var productController = new ProductController(orderService);

            // Act
            var result = await productController.IndexAsync() as ViewResult;
            var modelResult = result.ViewData.Model as IEnumerable<Line>;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(modelResult.ToList().Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task ProductController_IndexAsync_TenOrders_ReturnsFiveOrders()
        {
            // Arrange    
            var inProgressData = _dummyData.Content
                .Where(x => x.Status == Status.IN_PROGRESS.ToString())
                .ToList();

            var orderServiceMock = new Mock<IOrderService>();
            orderServiceMock.Setup(x => x.GetOrders(Status.IN_PROGRESS))
                .ReturnsAsync(inProgressData);

            var orderService = orderServiceMock.Object;

            var productController = new ProductController(orderService);

            // Act
            var result = await productController.IndexAsync() as ViewResult;
            var modelResult = result.ViewData.Model as IEnumerable<Line>;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(inProgressData.SelectMany(x => x.Lines).Count(), Is.EqualTo(10));
            Assert.That(modelResult.ToList().Count(), Is.EqualTo(5));
        }

        [Test]
        public async Task ProductController_IndexAsync_TwoOrders_ReturnsTwoOrders()
        {
            // Arrange
            var truncatedOrders = _dummyData.Content
                .First().Lines
                .Take(2).ToArray();

            _dummyData.Content.First().Lines = truncatedOrders;

            // Arrange    
            var inProgressData = _dummyData.Content
                .Where(x => x.Status == Status.IN_PROGRESS.ToString())
                .ToList();

            var orderServiceMock = new Mock<IOrderService>();
            orderServiceMock.Setup(x => x.GetOrders(Status.IN_PROGRESS))
                .ReturnsAsync(inProgressData);

            var orderService = orderServiceMock.Object;

            var productController = new ProductController(orderService);

            // Act
            var result = await productController.IndexAsync() as ViewResult;
            var modelResult = result.ViewData.Model as IEnumerable<Line>;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(modelResult.ToList().Count(), Is.EqualTo(2));
        }
    }
}