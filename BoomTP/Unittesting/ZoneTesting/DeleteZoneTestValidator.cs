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
    public class DeleteZoneTestValidator
    {
        private DeleteZoneValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new DeleteZoneValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Id_is_null()
        {
            DeleteZoneCommand deleteZoneCommand = new DeleteZoneCommand
            {
                Id = null
            };
            var result = validator.TestValidate(deleteZoneCommand);
            result.ShouldHaveValidationErrorFor(z => z.Id);
        }

        [TestMethod]
        public void Should_not_have_error_when_Id_is_specified()
        {
            DeleteZoneCommand deleteZoneCommand = new DeleteZoneCommand
            {
                Id = 1
            };
            var result = validator.TestValidate(deleteZoneCommand);
            result.ShouldNotHaveValidationErrorFor(z => z.Id);
        }
    }
}