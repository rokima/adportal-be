using adportal_be.Controllers;
using adportal_be.Data;
using adportal_be.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Web.Http;
using System.Web.Http.Results;
using System.Linq;
using System.Linq.Expressions;
using Assert = NUnit.Framework.Assert;
using System;
using System.Net;

namespace Tests
{
    public class AdvertismentsControllerTests
    {
        [Test]
        public void AdvertismentsGetWoParameterTest()
        {
            // Arrange
            //var mockRepository = new Mock<IMovieRepository>();
            AdPortalDbContext adPortalDbContext = new AdPortalDbContext();
            //var mockRepository = new Mock<AdPortalDbContext>();
            //var controller = new ImagesController(mockRepository.Object);
            //var controller = new ImagesController();
            //var m = new Mock<AdPortalDbContext>();
            var c = new AdvertisementsController(adPortalDbContext);

            /// var c = m.Object;
            //var u = c.Get();
            //controller.adPortalDbContext = adPortalDbContext;
            //var model = new Image()
            //{
            //    Id = 1,
            //    FileName = "pilt",
            //    ImageUrl = "www.pilt.ee",
            //};

            // Act    
            //var n = 4;
            //var actionResult = c.Get();
            //var s = actionResult as OkNegotiatedContentResult<Image>;

            //var createdResult = actionResult as  CreatedAtRouteNegotiatedContentResult<Image>;
            //var r = actionResult as RedirectToRouteResult;
            //var mo = r.Model as Image;
            // Assert
            //Assert.IsNotNull(s);
            //Assert.AreEqual(s.Content.Id, n);
            //Assert.IsNotNull(c..Content);

            //Assert.AreEqual("DefaultApi", createdResult.RouteName);
            //var f = c.adPortalDbContext.Images.FirstOrDefault(x => x.Id == n);
            //Assert.AreEqual(f.Id, c.Get(n));//createdResult.RouteValues["id"]);
        }
        [Test]

        public void AdevertismentsGetMethodWithParameterReturnTest()
        {
            // Arrange
            //var mockRepository = new Mock<IMovieRepository>();
            AdPortalDbContext adPortalDbContext = new AdPortalDbContext();
            //var mockRepository = new Mock<AdPortalDbContext>();
            //var controller = new ImagesController(mockRepository.Object);
            //var controller = new ImagesController();
            //var m = new Mock<AdPortalDbContext>();
            var c = new AdvertisementsController(adPortalDbContext);
            //var c = new ImagesController(adPortalDbContext);

            /// var c = m.Object;
            //var u = c.Get();
            //controller.adPortalDbContext = adPortalDbContext;
            //var model = new Image()
            //{
            //    Id = 1,
            //    FileName = "pilt",
            //    ImageUrl = "www.pilt.ee",
            //};

            // Act    
            var n = 4;
            var actionResult = c.Get(n);
            var s = actionResult as OkNegotiatedContentResult<Advertisement>;

            //var createdResult = actionResult as  CreatedAtRouteNegotiatedContentResult<Image>;
            //var r = actionResult as RedirectToRouteResult;
            //var mo = r.Model as Image;
            // Assert
            Assert.IsNotNull(s);
            Assert.AreEqual(s.Content.Id, n);
            //Assert.IsNotNull(c..Content);

            //Assert.AreEqual("DefaultApi", createdResult.RouteName);
            //var f = c.adPortalDbContext.Images.FirstOrDefault(x => x.Id == n);
            //Assert.AreEqual(f.Id, c.Get(n));//createdResult.RouteValues["id"]);
        }
        /*public void GetReturnsImageWithSameId()
        {
            var mockRepository = new Mock<AdPortalDbContext>();
            mockRepository.SetupAdd(x => x.Images.Find(0));

            var controller = new ImagesController();
            // Act
            IHttpActionResult actionResult = controller.Get(1);
            var contentResult = actionResult as OkNegotiatedContentResult<Image>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }**/
        [Test]
        public void AdvertismentsPostMethodSetsLocationHeader()
        {
            // Arrange
            //var mockRepository = new Mock<AdPortalDbContext>();
            AdPortalDbContext adPortalDbContext = new AdPortalDbContext();
            var controller = new AdvertisementsController(adPortalDbContext);
            var model = new Advertisement()
            {
                Title = "kuulutus",
                Description = "kuulutus",
                Price = 15,
                Active = true,
                CreationDate = DateTime.Now,

            };

            // Act    
            controller.Post(model);
            IHttpActionResult actionResult = controller.Get(1);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Advertisement>;

            // Assert
            //Assert.IsNotNull(createdResult);
            Assert.AreEqual("kuulutus", createdResult.Content.Title);
            //Assert.AreEqual(201, AdvertisementsController(model));
            //Assert.AreEqual(HttpStatusCode.Created, )
            //Assert.AreEqual("DefaultApi", createdResult.RouteName);
            //Assert.AreEqual(model.Title, createdResult.RouteValues["title"]);
        }

        //public IHttpActionResult Post([FromBody] Advertisement advertisement)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    advertisement.CreationDate = DateTime.Now;
        //    adPortalDbContext.Advertisements.Add(advertisement);
        //    adPortalDbContext.SaveChanges();
        //    return StatusCode(HttpStatusCode.Created);
        //}

        [Test]
        public void AdevertismentsGetMethodWithPaameterReturnTest()
        {
            // Arrange
            //var mockRepository = new Mock<IMovieRepository>();
            AdPortalDbContext adPortalDbContext = new AdPortalDbContext();
            //var mockRepository = new Mock<AdPortalDbContext>();
            //var controller = new ImagesController(mockRepository.Object);
            //var controller = new ImagesController();
            //var m = new Mock<AdPortalDbContext>();
            var c = new AdvertisementsController(adPortalDbContext);
            //var c = new ImagesController(adPortalDbContext);

            /// var c = m.Object;
            //var u = c.Get();
            //controller.adPortalDbContext = adPortalDbContext;
            //var model = new Image()
            //{
            //    Id = 1,
            //    FileName = "pilt",
            //    ImageUrl = "www.pilt.ee",
            //};

            // Act    
            var n = 1;
            var actionResult = c.Get(n);
            var s = actionResult as OkNegotiatedContentResult<Advertisement>;

            //var createdResult = actionResult as  CreatedAtRouteNegotiatedContentResult<Image>;
            //var r = actionResult as RedirectToRouteResult;
            //var mo = r.Model as Image;
            // Assert
            Assert.IsNotNull(s);
            Assert.AreEqual(s.Content.Id, n);
            //Assert.IsNotNull(c..Content);

            //Assert.AreEqual("DefaultApi", createdResult.RouteName);
            //var f = c.adPortalDbContext.Images.FirstOrDefault(x => x.Id == n);
            //Assert.AreEqual(f.Id, c.Get(n));//createdResult.RouteValues["id"]);
        }


    }
}