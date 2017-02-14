using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Offer.Builders
{
    public static class ExtentionMethods
    {
        public static IDbSet<T> Initialize<T>(this IDbSet<T> dbSet, IQueryable<T> data) where T : class
        {
            dbSet.Provider.Returns(data.Provider);
            dbSet.Expression.Returns(data.Expression);
            dbSet.ElementType.Returns(data.ElementType);
            dbSet.GetEnumerator().Returns(data.GetEnumerator());
            return dbSet;
        }
    }
    [TestFixture]
    public class OffersFromBuyerViewModelBuilderTest
    {
        private IOrangeBricksContext _context;
       
        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuildShouldReturnOffersMadeForTheSpecifiedUser()
        {
            // Arrange
            var builder = new OffersFromBuyerViewModelBuilder(_context);
            var user1 = System.Guid.NewGuid().ToString();
            var user2 = System.Guid.NewGuid().ToString();
            var offers = new List<Models.Offer>() {
                new Models.Offer() {Amount = 100000,  UserId = user1,  Property = new Models.Property() { Id =1, NumberOfBedrooms =3, PropertyType =  "House" } },
                new Models.Offer() {Amount = 125000,  UserId = user2,  Property = new Models.Property() { Id =1, NumberOfBedrooms =3, PropertyType =  "House" } },
            };

            var mockSet = Substitute.For<IDbSet<Models.Offer>>()
                .Initialize(offers.AsQueryable());

            _context.Offers.Returns(mockSet);

            // Act
            var viewModel = builder.Build(user1);

            // Assert
            Assert.That(viewModel.Offers.Count, Is.EqualTo(1));
            Assert.That(viewModel.Offers[0].Amount, Is.EqualTo(100000));

        }
    }
}
