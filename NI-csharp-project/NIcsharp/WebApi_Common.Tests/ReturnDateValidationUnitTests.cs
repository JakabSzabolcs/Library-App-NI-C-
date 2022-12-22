using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
using WebApi_Common.Models;

namespace WebApi_Common.Tests
{
    [TestClass]
    public class ReturnDateValidationUnitTests : ReturnDateValidation
    {
        [TestMethod]
        public void IsValid_WithValidDate_ValidationSuccess()
        {
            // Arrange
            var date = DateTime.Now.AddDays(1);
            var validationContext = new ValidationContext(date);
            var attribute = new ReturnDateValidation();

            // Act
            ValidationResult validationResult = attribute.GetValidationResult(date, validationContext);

            // Assert
            Assert.AreEqual(validationResult, ValidationResult.Success);
        }
        
        [TestMethod]
        public void IsValid_WithInvalidDate_ReturnsError()
        {
            // Arrange
            var date = DateTime.Now.AddDays(-1);
            var validationContext = new ValidationContext(date);
            var attribute = new ReturnDateValidation();

            // Act
            ValidationResult validationResult = attribute.GetValidationResult(date, validationContext);

            // Assert
            Assert.AreEqual(validationResult.ErrorMessage, "The return date cannot be less then the borrowing date");
        }
    }
}
