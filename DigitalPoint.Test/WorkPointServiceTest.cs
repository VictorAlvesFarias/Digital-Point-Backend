using DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoint;
using DigitalPoint.Application.Interfaces.BaseRepository;
using DigitalPoint.Application.Interfaces.Identity;
using DigitalPoint.Application.Interfaces.WorkPoints;
using DigitalPoint.Domain.Entities;
using DigitalPoint.Domain.Services;
using NSubstitute;
using System.Runtime.InteropServices;

namespace DigitalPoint.Test
{
    public class WorkPointServiceTest
    {

        private readonly IWorkPointRepository _workPointRepository;

        private readonly IBaseRepository<WorkPoint> _baseRepository;

        private readonly IIdentityService _identityService;

        private readonly WorkPointService _workPointService;

        private readonly WorkPoint _workPoint;

        private readonly ApplicationUser _applicationUser;

        private readonly InsertWorkPointRequest _insertWorkPointRequest;

        public WorkPointServiceTest() {

            _workPointRepository = Substitute.For<IWorkPointRepository>();

            _baseRepository = Substitute.For<IBaseRepository<WorkPoint>>();

            _identityService = Substitute.For<IIdentityService>();

            _workPointService = new WorkPointService(
                _workPointRepository,
                _baseRepository,
                _identityService
            );

            _applicationUser = new ApplicationUser(){
                Name = "Victor",
                Id = "06af15d6-677c-4512-a893-dc606756de09",
                UserName = "victoralvesfarias2004@gmail.com",
                Email = "victoralvesfarias2004@gmail.com"
            };
   
            _workPoint = WorkPoint.Create(
                DateTime.Parse("2023 - 09 - 27T00: 00:00.000Z"),
                DateTime.Parse("2023 - 09 - 27T00: 00:00.000Z"),
                _applicationUser
            );

            _insertWorkPointRequest = new InsertWorkPointRequest() { 
                DepartureTime = DateTime.Parse("2023 - 09 - 27T00: 00:00.000Z"),
                EntryTime = DateTime.Parse("2023 - 09 - 27T00: 00:00.000Z")
            };

        }  

        [Fact]
        public async Task InsertWorkPointTrue()
        {
            _identityService.FindByIdAsync(_applicationUser.Id).Returns(_applicationUser);

            var result = await _workPointService.InsertWorkPoint(_insertWorkPointRequest, _applicationUser.Id);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task InsertWorkPointFalse()
        {
            var result = await _workPointService.InsertWorkPoint(_insertWorkPointRequest, _applicationUser.Id);

            Assert.False(result.Success);
        }
    }
}