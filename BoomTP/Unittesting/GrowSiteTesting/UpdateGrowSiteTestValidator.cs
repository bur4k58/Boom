using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittesting.GrowSiteTesting
{
    [TestClass]
    public class UpdateGrowSiteTestValidator
    {
        private UpdateGrowSiteValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new UpdateGrowSiteValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Addresses_is_null()
        {
            UpdateGrowSiteCommand updateGrowSiteCommand = new UpdateGrowSiteCommand
            {
                Name = "Test",
                Address = null,
                Map = "Test"
            };
            var result = validator.TestValidate(updateGrowSiteCommand);
            result.ShouldHaveValidationErrorFor(gs => gs.Address);
        }

        [TestMethod]
        public void Should_not_have_error_when_Addresses_is_specified()
        {
            UpdateGrowSiteCommand updateGrowSiteCommand = new UpdateGrowSiteCommand
            {
                Name = "Test",
                Address = "Test",
                Map = "Test"
            };
            var result = validator.TestValidate(updateGrowSiteCommand);
            result.ShouldNotHaveValidationErrorFor(gs => gs.Address);
        }
    }
}