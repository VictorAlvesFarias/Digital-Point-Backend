﻿using DigitalPoint.Application.Dtos.Default;
using DigitalPoint.Application.Dtos.WorkPoints.GetAllWorkPoints;
using DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoint;
using DigitalPoint.Application.Dtos.WorkPoints.PutWorkPoint;
using DigitalPoint.Application.Interfaces.BaseRepository;
using DigitalPoint.Application.Interfaces.Identity;
using DigitalPoint.Application.Interfaces.WorkPoints;
using DigitalPoint.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.Design;

namespace DigitalPoint.Domain.Services
{
    public class WorkPointService : IWorkPointService
    {
        private readonly IWorkPointRepository _workPointRepository;

        private readonly IBaseRepository<WorkPoint> _baseRepository;

        private readonly WorkPoint _wordPoint;

        private readonly IIdentityService _userManager;

        public WorkPointService
        (
            IWorkPointRepository workPointRepository,
            IBaseRepository<WorkPoint> baseRepository,
            IIdentityService userManager
        )
        {
            _userManager = userManager;
            _baseRepository = baseRepository;
            _workPointRepository = workPointRepository;
        }
        public async Task<PutWorkPointResponse> PutWorkPoint(PutWorkPointRequest putWorkPointRequest, string userId, int workPointId)
        {
            var item = await _baseRepository.GetAsync(workPointId);

            if (item.ApplicationUserId == userId)
            {
                item.Update(
                   entryTime: putWorkPointRequest.EntryTime.ToUniversalTime(),
                   departureTime: putWorkPointRequest.DepartureTime.ToUniversalTime()
               );

                _baseRepository.UpdateAsync(item);

                return new PutWorkPointResponse(true);
            }

            var result = new PutWorkPointResponse(false);

            result.AddError("Não autorizado");

            return result;
        }
        public async Task<DefaultResponse> DeleteWorkPoint(int workPointId, string userId)
        {
            var item = await _baseRepository.GetAsync(workPointId);

            if (item.ApplicationUserId == userId)
            {
                _baseRepository.RemoveAsync(item);

                return new DefaultResponse(true);
            }

            var result = new DefaultResponse(false);

            result.AddError("Não autorizado");

            return result;
        }
        public async Task<GetAllWorkPointResponse> GetAllWorkPoints(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var workPointsList = await _workPointRepository.GetAllAsync(user);

            var result = new GetAllWorkPointResponse()
            {
                Success = true,
                WorkPointsList = from list in workPointsList
                                 select new GetAllWorkPointResponse.WorkPoints()
                                 {
                                     Id = list.Id,
                                     DepartureTime = list.DepartureTime.ToUniversalTime(),
                                     EntryTime = list.EntryTime.ToUniversalTime()
                                 }
            };

            return result;
        }
        public async Task<InsertWorkPointResponse> InsertWorkPoint(InsertWorkPointRequest workPoint, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new InsertWorkPointResponse(false);
            }
            else
            {
                var item = WorkPoint.Create
                (
                    departureTime: workPoint.DepartureTime,
                    applicationUser: user,
                    entryTime: workPoint.EntryTime
                );

                _baseRepository.AddAsync(item);
                
                return new InsertWorkPointResponse(true);
            }



        }
    }
}
