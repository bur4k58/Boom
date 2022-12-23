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
    public class CreateTreeSpeciesTestValidator
    {
        private CreateTreeSpeciesValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new CreateTreeSpeciesValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Name_is_null()
        {
            CreateTreeSpeciesCommand createTreeSpeciesCommand = new CreateTreeSpeciesCommand
            {
                 ImageUrl = "Test",
                 MaintenanceInstructions = "Test",
                 Name = null
            };
            var result = validator.TestValidate(createTreeSpeciesCommand);
            result.ShouldHaveValidationErrorFor(t => t.Name).WithErrorMessage("Name can not be null");
        }

        [TestMethod]
        public void Should_not_have_error_when_Name_is_specified()
        {
            CreateTreeSpeciesCommand createTreeSpeciesCommand = new CreateTreeSpeciesCommand
            {
                ImageUrl = "Test",
                MaintenanceInstructions = "Test",
                Name = "Test"
            };
            var result = validator.TestValidate(createTreeSpeciesCommand);
            result.ShouldNotHaveValidationErrorFor(t => t.Name);
        }
    }
}