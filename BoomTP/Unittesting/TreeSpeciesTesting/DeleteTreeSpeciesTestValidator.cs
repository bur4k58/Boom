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
    public class DeleteTreeSpeciesTestValidator
    {
        private DeleteTreeSpeciesValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new DeleteTreeSpeciesValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Id_is_null()
        {
            DeleteTreeSpeciesCommand deleteTreeSpeciesCommand = new DeleteTreeSpeciesCommand
            {
                Id = null
            };
            var result = validator.TestValidate(deleteTreeSpeciesCommand);
            result.ShouldHaveValidationErrorFor(t => t.Id).WithErrorMessage("Id can not be null");
        }

        [TestMethod]
        public void Should_not_have_error_when_Id_is_specified()
        {
            DeleteTreeSpeciesCommand deleteTreeSpeciesCommand = new DeleteTreeSpeciesCommand
            {
                Id = 1
            };
            var result = validator.TestValidate(deleteTreeSpeciesCommand);
            result.ShouldNotHaveValidationErrorFor(t => t.Id);
        }
    }
}