using FluentValidation.TestHelper;
using AP.BoomTP.Application.CQRS.ScheduleTaskCQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittesting.ScheduleTaskTesting
{
    [TestClass]
    public class UpdateScheduleTaskTestValidator
    {
        private UpdateScheduleTaskValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new UpdateScheduleTaskValidator();
        }

        [TestMethod]
        public void Should_have_error_when_ScheduleId_is_null()
        {
            UpdateScheduleTaskCommand updateScheduleTask = new UpdateScheduleTaskCommand
            {
                ScheduleId = null,
                TasksId = 2,
                Status = AP.BoomTP.Domain.Status.Start
            };
            var result = validator.TestValidate(updateScheduleTask);
            result.ShouldHaveValidationErrorFor(st => st.ScheduleId);
        }

        [TestMethod]
        public void Should_have_error_when_TasksId_is_null()
        {
            UpdateScheduleTaskCommand updateScheduleTask = new UpdateScheduleTaskCommand
            {
                ScheduleId = 1,
                TasksId = null,
                Status = AP.BoomTP.Domain.Status.Start
            };
            var result = validator.TestValidate(updateScheduleTask);
            result.ShouldHaveValidationErrorFor(st => st.TasksId);
        }

        [TestMethod]
        public void Should_not_have_error_when_ScheduleId_is_specified()
        {
            UpdateScheduleTaskCommand updateScheduleTask = new UpdateScheduleTaskCommand
            {
                ScheduleId = 1,
                TasksId = 2,
                Status = AP.BoomTP.Domain.Status.Start
            };
            var result = validator.TestValidate(updateScheduleTask);
            result.ShouldNotHaveValidationErrorFor(st => st.ScheduleId);
        }

        [TestMethod]
        public void Should_not_have_error_when_TasksId_is_specified()
        {
            UpdateScheduleTaskCommand updateScheduleTask = new UpdateScheduleTaskCommand
            {
                ScheduleId = 1,
                TasksId = 2,
                Status = AP.BoomTP.Domain.Status.Start
            };
            var result = validator.TestValidate(updateScheduleTask);
            result.ShouldNotHaveValidationErrorFor(st => st.TasksId);
        }
    }
}