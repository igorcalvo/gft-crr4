// ConsolidationServiceTests.cs
using CashFlow.Core.Services;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace CashFlow.Tests.Services
{
    public class ConsolidationServiceTests
    {
        private readonly Mock<IEntryRepository> _entryRepoMock = new();
        private readonly Mock<IConsolidationRepository> _consolidationRepoMock = new();
        private readonly ConsolidationService _service;

        public ConsolidationServiceTests()
        {
            _service = new ConsolidationService(_consolidationRepoMock.Object, _entryRepoMock.Object);
        }

        [Fact]
        public async Task AddConsolidation_ShouldCalculateCorrectSumsAndCallAddAsync()
        {
            var today = DateTime.Today;
            var entries = new List<Entry>
        {
            new() { Amount = 100, Type = EntryTypeEnum.Credit },
            new() { Amount = 50, Type = EntryTypeEnum.Debit }
        };

            _entryRepoMock.Setup(r => r.GetByDateAsync(today)).ReturnsAsync(entries);

            await _service.AddConsolidation();

            _consolidationRepoMock.Verify(x => x.AddAsync(It.Is<Consolidation>(c =>
                c.TotalCredit == 100 &&
                c.TotalDebit == 50)), Times.Once);
        }

        [Fact]
        public async Task GetResultFromDate_ShouldReturnCorrectData()
        {
            var date = DateTime.Today.AddDays(-10);
            var expected = new Consolidation();
            _consolidationRepoMock.Setup(x => x.GetByDateAsync(date)).ReturnsAsync(expected);

            var result = await _service.GetResultFromDate(date);

            result.Should().Be(expected);
        }

        [Fact]
        public async Task GetTodaysResult_ShouldCallGetResultFromDate()
        {
            var today = DateTime.Today;
            var expected = new Consolidation();
            _consolidationRepoMock.Setup(x => x.GetByDateAsync(today)).ReturnsAsync(expected);

            var result = await _service.GetTodaysResult();

            result.Should().Be(expected);
        }
    }
}