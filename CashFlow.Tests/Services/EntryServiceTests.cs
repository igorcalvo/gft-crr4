using AutoMapper;
using CashFlow.Core.Services;
using CashFlow.Domain.DTOs;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace CashFlow.Tests.Services
{
    public class EntryServiceTests
    {
        private readonly Mock<IEntryRepository> _entryRepoMock = new();
        private readonly Mock<ICounterpartyRepository> _counterpartyRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly EntryService _service;

        public EntryServiceTests()
        {
            _service = new EntryService(_entryRepoMock.Object, _counterpartyRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task DeleteAsync_ThrowsIfDateIsTodayOrEarlier()
        {
            var entry = new Entry { Id = Guid.NewGuid(), CreatedAt = DateTime.Today };
            _entryRepoMock.Setup(x => x.GetByIdAsync(entry.Id)).ReturnsAsync(entry);

            var act = async () => await _service.DeleteAsync(entry.Id);
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Registros passados não podem ser deletados");
        }
    }
}