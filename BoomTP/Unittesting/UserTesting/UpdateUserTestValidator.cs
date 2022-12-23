using AP.BoomTP.Application.CQRS.UserCQRS;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittesting.UserTesting
{
    [TestClass]
    public class UpdateUserTestValidator
    {
        private UpdateUserCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new UpdateUserCommandValidator();
        }
        [TestMethod]
        public void Should_have_error_when_Auth_Id_is_null()
        {
            UpdateUserCommand updateUserCommand = new UpdateUserCommand
            {
                AuthId = null,
                ContractType = ContractType.Fulltime,
                Role = Role.Admin,
                Email = "Test",
                FirstName = "Test",
                LastName = "Test"
            };
            var result = validator.TestValidate(updateUserCommand);
            result.ShouldHaveValidationErrorFor(u => u.AuthId).WithErrorMessage("AuthId can not be null");
        }

        [TestMethod]
        public void Should_have_error_when_LastName_is_null()
        {
            UpdateUserCommand updateUserCommand = new UpdateUserCommand
            {
                AuthId = "Test",
                ContractType = ContractType.Fulltime,
                Role = Role.Admin,
                Email = "Test",
                FirstName = "Test",
                LastName = null
            };
            var result = validator.TestValidate(updateUserCommand);
            result.ShouldHaveValidationErrorFor(u => u.LastName).WithErrorMessage("LastName can not be null");
        }

        [TestMethod]
        public void Should_have_error_when_Email_is_null()
        {
            UpdateUserCommand updateUserCommand = new UpdateUserCommand
            {
                AuthId = "Test",
                ContractType = ContractType.Fulltime,
                Role = Role.Admin,
                Email = null,
                FirstName = "Test",
                LastName = "Test"
            };
            var result = validator.TestValidate(updateUserCommand);
            result.ShouldHaveValidationErrorFor(u => u.Email).WithErrorMessage("Email can not be null");
        }

        [TestMethod]
        public void Should_not_have_error_when_propertys_is_specified()
        {
            UpdateUserCommand updateUserCommand = new UpdateUserCommand
            {
                AuthId = "Test",
                ContractType = ContractType.Fulltime,
                Role = Role.Admin,
                Email = "Test",
                FirstName = "Test",
                LastName = "Test"
            };
            var result = validator.TestValidate(updateUserCommand);
            result.ShouldNotHaveValidationErrorFor(u => u.AuthId);
            result.ShouldNotHaveValidationErrorFor(u => u.FirstName);
            result.ShouldNotHaveValidationErrorFor(u => u.Email);
        }
    }
}