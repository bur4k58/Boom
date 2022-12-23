using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittesting.TreeSpeciesTesting
{
    [TestClass]
    public class UpdateTreeSpeciesTestValidator
    {
        private UpdateTreeSpeciesValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new UpdateTreeSpeciesValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Name_is_null()
        {
            UpdateTreeSpeciesCommand updateTreeSpeciesCommand = new UpdateTreeSpeciesCommand
            {
                ImageUrl = "Test",
                MaintenanceInstructions = "Test",
                Name = null
            };
            var result = validator.TestValidate(updateTreeSpeciesCommand);
            result.ShouldHaveValidationErrorFor(t => t.Name).WithErrorMessage("Name can not be null");
        }

        [TestMethod]
        public void Should_not_have_error_when_Name_is_specified()
        {
            UpdateTreeSpeciesCommand updateTreeSpeciesCommand = new UpdateTreeSpeciesCommand
            {
                ImageUrl = "Test",
                MaintenanceInstructions = "Test",
                Name = "Test"
            };
            var result = validator.TestValidate(updateTreeSpeciesCommand);
            result.ShouldNotHaveValidationErrorFor(t => t.Name);
        }
    }
}