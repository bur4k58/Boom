using AP.BoomTP.Application.CQRS.ZoneCQRS;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittesting.ZoneTesting
{
    [TestClass]
    public class UpdateZoneTestValidator
    {
        private UpdateZoneValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new UpdateZoneValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Name_is_null()
        {
            UpdateZoneCommand updateZoneCommand = new UpdateZoneCommand
            {
                Name = null,
                QrCode = "Test",
                Size = "Test",
                GrowSiteId = 1,
                TreeSpeciesId = 1
            };
            var result = validator.TestValidate(updateZoneCommand);
            result.ShouldHaveValidationErrorFor(z => z.Name).WithErrorMessage("Name can not be null");
        }

        [TestMethod]
        public void Should_have_error_when_GrowSiteId_is_null()
        {
            UpdateZoneCommand updateZoneCommand = new UpdateZoneCommand
            {
                Name = "Test",
                QrCode = "Test",
                Size = "Test",
                GrowSiteId = null,
                TreeSpeciesId = 1
            };
            var result = validator.TestValidate(updateZoneCommand);
            result.ShouldHaveValidationErrorFor(z => z.GrowSiteId).WithErrorMessage("GrowSiteId can not be null");
        }

        [TestMethod]
        public void Should_have_error_when_TreeSpeciesId_is_null()
        {
            UpdateZoneCommand updateZoneCommand = new UpdateZoneCommand
            {
                Name = "Test",
                QrCode = "Test",
                Size = "Test",
                GrowSiteId = 1,
                TreeSpeciesId = null
            };
            var result = validator.TestValidate(updateZoneCommand);
            result.ShouldHaveValidationErrorFor(z => z.TreeSpeciesId).WithErrorMessage("TreeSpeciesId can not be null");
        }

        [TestMethod]
        public void Should_not_have_error_when_propertys_is_specified()
        {
            UpdateZoneCommand updateZoneCommand = new UpdateZoneCommand
            {
                Name = "Test",
                QrCode = "Test",
                Size = "Test",
                GrowSiteId = 1,
                TreeSpeciesId = 1
            };
            var result = validator.TestValidate(updateZoneCommand);
            result.ShouldNotHaveValidationErrorFor(z => z.Name);
            result.ShouldNotHaveValidationErrorFor(z => z.GrowSiteId);
            result.ShouldNotHaveValidationErrorFor(z => z.TreeSpeciesId);
        }
    }
}