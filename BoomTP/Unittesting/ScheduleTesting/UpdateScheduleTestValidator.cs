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
    public class UpdateScheduleTestValidator
    {
        private UpdateScheduleValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new UpdateScheduleValidator();
        }

        [TestMethod]
        public void Should_have_error_when_ZoneId_is_null()
        {
            int[] list = new int[] { 1 };
            UpdateScheduleCommand updateScheduleCommand = new UpdateScheduleCommand
            {
                Date = DateTime.Now,
                Id = 1,
                UserId = 1,
                ZoneId = null,
               //TaskIds = list
            };
            var result = validator.TestValidate(updateScheduleCommand);
            result.ShouldHaveValidationErrorFor(s => s.ZoneId);
        }

        [TestMethod]
        public void Should_not_have_error_when_ZoneId_is_specified()
        {
            int[] list = new int[] { 1 };
            UpdateScheduleCommand updateScheduleCommand = new UpdateScheduleCommand
            {
                Date = DateTime.Now,
                Id = 1,
                UserId = 1,
                ZoneId = 1,
                //TaskIds = list
            };
            var result = validator.TestValidate(updateScheduleCommand);
            result.ShouldNotHaveValidationErrorFor(s => s.ZoneId);
        }
    }
}