using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeviceManager.Application.DTOs;
using DeviceManager.Application.Mappings;
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
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
            _service = new ClienteService(_mockRepo.Object, _mapper);
        }
        [Fact]
        public async Task CreateAsync_RetornaDto()
        {
            var dto = new CreateClienteDto
            {
                Nome = "Test Client",
                Email = "test@example.com",
                Telefone = "1234567890",
                Status = true
            };

            _mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<Cliente>())).ReturnsAsync((Cliente c) =>
            {
                c.Id = Guid.NewGuid();
                return c;
            });

            var result = await _service.CreateAsync(dto);

            Assert.NotNull(result);
            Assert.IsType<ClienteDto>(result);
            Assert.NotEqual(Guid.Empty, result.Id);
            Assert.Equal(dto.Nome, result.Nome);
            Assert.Equal(dto.Email, result.Email);
            Assert.Equal(dto.Telefone, result.Telefone);
            Assert.Equal(dto.Status, result.Status);
        }
        
        [Fact]
        public async Task GetAllAsync_RetornaListaDeClientes()
        {
            var clientes = new List<Cliente>
            {
                new() { Id = Guid.NewGuid(), Nome = "Client 1", Email = "client1@example.com", Telefone = "1234567890", Status = true },
                new() { Id = Guid.NewGuid(), Nome = "Client 2", Email = "client2@example.com", Telefone = "0987654321", Status = false }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(clientes);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<ClienteDto>>(result);
            Assert.Equal(clientes.Count, result.Count());
        }
    }
}