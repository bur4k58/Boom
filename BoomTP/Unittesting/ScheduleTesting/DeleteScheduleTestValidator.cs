using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittesting.ScheduleTesting
{
    [TestClass]
    public class DeleteScheduleTestValidator
    {
        private DeleteScheduleValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new DeleteScheduleValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Id_is_null()
        {
            DeleteScheduleCommand deleteScheduleCommand = new DeleteScheduleCommand
            {
                Id = null
            };
            var result = validator.TestValidate(deleteScheduleCommand);
            result.ShouldHaveValidationErrorFor(s => s.Id);
        }

        [TestMethod]
        public void Should_not_have_error_when_Id_is_specified()
        {
            DeleteScheduleCommand deleteScheduleCommand = new DeleteScheduleCommand
            {
                Id = 1
            };
            var result = validator.TestValidate(deleteScheduleCommand);
            result.ShouldNotHaveValidationErrorFor(gs => gs.Id);
        }
    }
}