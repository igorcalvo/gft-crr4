using CashFlow.Core.Services;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace CashFlow.Tests.Services
{
    public class CounterpartyServiceTests
    {
        private readonly Mock<ICounterpartyRepository> _counterpartyRepoMock = new();
        private readonly Mock<IEntryRepository> _entryRepoMock = new();
        private readonly CounterpartyService _service;

        public CounterpartyServiceTests()
        {
            _service = new CounterpartyService(_counterpartyRepoMock.Object, _entryRepoMock.Object);
        }

        [Fact]
        public async Task AddAsync_ThrowsIfAlreadyExists()
        {
            var cp = new Counterparty { Id = Guid.NewGuid() };
            _counterpartyRepoMock.Setup(r => r.GetByIdAsync(cp.Id)).ReturnsAsync(new Counterparty());

            var act = async () => await _service.AddAsync(cp);
            await act.Should().ThrowAsync<InvalidOperationException>().WithMessage("Esse registro já existe");
        }

        [Fact]
        public async Task DeleteAsync_ThrowsIfHasAssociatedEntries()
        {
            var id = Guid.NewGuid();
            _entryRepoMock.Setup(r => r.GetByCounterpartyIdAsync(id)).ReturnsAsync(new List<Entry> { new() });

            var act = async () => await _service.DeleteAsync(id);
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Há registros associados a essa counterparty então não pode ser deletada");
        }
    }
}