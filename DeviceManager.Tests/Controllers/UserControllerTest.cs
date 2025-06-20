using AutoMapper;
using DeviceManager.Api.Controllers;
using DeviceManager.Application.DTOs;
using DeviceManager.Application.Interfaces;
using DeviceManager.Application.Mappings;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DeviceManager.Tests.Controllers
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _mockService;
        private readonly IMapper _mapper;
        private readonly UserController _controller;

        public UserControllerTest()
        {
            _mockService = new Mock<IUserService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();

            _controller = new UserController(_mockService.Object);
        }

        [Fact]
        public async Task Create_ReturnaOk_UsuarioCriado()
        {
            // Arrange
            var inputDto = new CreateUserDto { Email = "test@example.com", Password = "password123", Perfil = "Admin" };
            var createdUser = _mapper.Map<UserDto>(inputDto);
            createdUser.Id = Guid.NewGuid();

            _mockService.Setup(s => s.CreateAsync(inputDto)).ReturnsAsync(createdUser);

            // Act
            var result = await _controller.Create(inputDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(createdUser, okResult.Value);
        }

        [Fact]
        public async Task Create_CallsServiceWithCorrectDto()
        {
            // Arrange
            var inputDto = new CreateUserDto { Email = "test@example.com", Password = "password123", Perfil = "Admin" };
            var createdUser = _mapper.Map<UserDto>(inputDto);
            createdUser.Id = Guid.NewGuid();

            _mockService.Setup(s => s.CreateAsync(inputDto)).ReturnsAsync(createdUser);

            // Act
            await _controller.Create(inputDto);

            // Assert
            _mockService.Verify(s => s.CreateAsync(inputDto), Times.Once);
        }

        [Fact]
        public async Task Create_RetornaNull_QuandoNull()
        {
            // Arrange
            var inputDto = new CreateUserDto { Email = "", Password = "", Perfil = "" };

            _mockService.Setup(s => s.CreateAsync(inputDto)).ReturnsAsync((UserDto?)null!);

            // Act
            var result = await _controller.Create(inputDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Null(okResult.Value);
        }
    }
}