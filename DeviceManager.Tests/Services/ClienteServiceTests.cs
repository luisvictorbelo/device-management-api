using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeviceManager.Application.DTOs;
using DeviceManager.Application.Services;
using DeviceManager.Domain.Entities;
using DeviceManager.Domain.Interfaces;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace DeviceManager.Tests.Services
{
    public class ClienteServiceTests
    {
        private readonly Mock<IClienteRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly ClienteService _service;

        public ClienteServiceTests()
        {
            _mockRepo = new Mock<IClienteRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cliente, ClienteDto>().ReverseMap();
            });

            _mapper = config.CreateMapper();
            _service = new ClienteService(_mockRepo.Object, _mapper);
        }
        [Fact]
        public async Task CreateAsync_ShouldReturnMappedDto()
        {
            var dto = new ClienteDto
            {
                Id = Guid.NewGuid(),
                Nome = "Test Client",
                Email = "test@example.com",
                Telefone = "1234567890",
                Status = true
            };

            _mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<Cliente>())).ReturnsAsync((Cliente c) => c);

            var result = await _service.CreateAsync(dto);

            Assert.NotNull(result);
            Assert.IsType<ClienteDto>(result);
            Assert.Equal(dto.Id, result.Id);
            Assert.Equal(dto.Nome, result.Nome);
            Assert.Equal(dto.Email, result.Email);
            Assert.Equal(dto.Telefone, result.Telefone);
            Assert.Equal(dto.Status, result.Status);
        }
    }
}