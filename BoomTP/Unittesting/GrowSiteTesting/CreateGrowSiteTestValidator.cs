using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.Interfaces;
using AP.BoomTP.Application.Interfaces.GrowSiteI;
using AP.BoomTP.Domain;
using AP.BoomTP.Infrastructure.Repositories;
using AutoMapper;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittesting.GrowSiteTesting
{
    [TestClass]
    public class CreateGrowSiteTestValidator
    {
        private CreateGrowSiteValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new CreateGrowSiteValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Address_is_null()
        {
            CreateGrowSiteCommand createGrowSiteCommand = new CreateGrowSiteCommand
            {
                Name = "vv",
                Address = null,
                Map = "dvdv"
            };
            var result = validator.TestValidate(createGrowSiteCommand);
            result.ShouldHaveValidationErrorFor(gs => gs.Address).WithErrorMessage("Addresses can not be null");
        }

        [TestMethod]
        public void Should_not_have_error_when_Address_is_specified()
        {
            CreateGrowSiteCommand createGrowSiteCommand = new CreateGrowSiteCommand
            {
                Name = "Test",
                Address = "Test",
                Map = "Test"
            };
            var result = validator.TestValidate(createGrowSiteCommand);
            result.ShouldNotHaveValidationErrorFor(gs => gs.Address);
        }
    }
}