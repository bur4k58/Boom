using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.ScheduleTaskCQRS;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittesting.ScheduleTaskTesting
{
    [TestClass]
    public class DeleteScheduleTaskTestValidator
    {
        private DeleteScheduleTaskValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new DeleteScheduleTaskValidator();
        }

        [TestMethod]
        public void Should_have_error_when_scheduleId_is_null()
        {
            DeleteScheduleTaskCommand deleteScheduleTaskCommand = new DeleteScheduleTaskCommand
            {
                ScheduleId = null,
                TasksId = null
            };
            var result = validator.TestValidate(deleteScheduleTaskCommand);
            result.ShouldHaveValidationErrorFor(st => st.ScheduleId);
        }

        [TestMethod]
        public void Should_have_error_when_tasksId_is_null()
        {
            DeleteScheduleTaskCommand deleteScheduleTaskCommand = new DeleteScheduleTaskCommand
            {
                ScheduleId = null,
                TasksId = null
            };
            var result = validator.TestValidate(deleteScheduleTaskCommand);
            result.ShouldHaveValidationErrorFor(st => st.TasksId);
        }

        [TestMethod]
        public void Should_not_have_error_when_scheduleId_is_specified()
        {
            DeleteScheduleTaskCommand deleteScheduleTaskCommand = new DeleteScheduleTaskCommand
            {
                ScheduleId = 1,
                TasksId = null
            };
            var result = validator.TestValidate(deleteScheduleTaskCommand);
            result.ShouldNotHaveValidationErrorFor(st => st.ScheduleId);
        }

        [TestMethod]
        public void Should_not_have_error_when_tasksId_is_specified()
        {
            DeleteScheduleTaskCommand deleteScheduleTaskCommand = new DeleteScheduleTaskCommand
            {
                ScheduleId = 1,
                TasksId = 1
            };
            var result = validator.TestValidate(deleteScheduleTaskCommand);
            result.ShouldNotHaveValidationErrorFor(st => st.TasksId);
        }
    }
}
