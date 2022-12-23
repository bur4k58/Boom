using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
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
    public class CreateScheduleTestValidator
    {
        private CreateScheduleCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new CreateScheduleCommandValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Propertys_is_null()
        {
            CreateScheduleCommand createScheduleCommand = new CreateScheduleCommand
            {
                Date = DateTime.Now,
                UserId = null,
                ZoneId = null
            };
            var result = validator.TestValidate(createScheduleCommand);
            result.ShouldHaveValidationErrorFor(gs => gs.UserId).WithErrorMessage("UserId can not be null");
            result.ShouldHaveValidationErrorFor(gs => gs.ZoneId).WithErrorMessage("ZoneId can not be null");
        }

        [TestMethod]
        public void Should_not_have_error_when_Propertys_is_specified()
        {
            int[] list = new int[] {1};
            CreateScheduleCommand createScheduleCommand = new CreateScheduleCommand
            {
                Date = DateTime.Now,

                UserId = 1,
                ZoneId = 1
            };
            var result = validator.TestValidate(createScheduleCommand);
            result.ShouldNotHaveValidationErrorFor(gs => gs.UserId);
            result.ShouldNotHaveValidationErrorFor(gs => gs.ZoneId);
        }
    }
}
