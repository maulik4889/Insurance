namespace Insurance.Application.UnitTests.Services.ClaimService;

using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Moq;
using Insurance.Application.Common.Interfaces;
using Insurance.Application.Common.RequestModels;
using Insurance.Application.Common.ViewModels;
using Insurance.Application.Services.ClaimService;
using Insurance.Domain.Entities;
using Xunit;
using Insurance.UnitTests.Core;

public class ClaimTests
{
    [Theory]
    [AutoMoqData]
    public async Task UpdateClaim_InNormalCircumstances_ShouldValidateBeforeBeginningTransaction(
    [Frozen] Mock<IUnitOfWork> unitOfWorkStub,
    ClaimService sut,
    int claimIdStub,
    Exception exceptionStub,
    UpdateClaimRequest updateClaimRequestStub
)
    {
        // Arrange
        unitOfWorkStub.Setup(x => x.BeginTransactionAsync())
            .ThrowsAsync(exceptionStub);

        // Act
        await Assert.ThrowsAsync<Exception>(async () => await sut.UpdateClaim(claimIdStub, updateClaimRequestStub));

        // Assert
        unitOfWorkStub.Verify(x => x.Claims.GetClaimById(claimIdStub), Times.Once());
    }
}
