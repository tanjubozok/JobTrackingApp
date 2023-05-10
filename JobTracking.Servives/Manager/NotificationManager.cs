using AutoMapper;
using JobTracking.Common.Abstract;
using JobTracking.Common.ComplexTypes;
using JobTracking.Common.ResponseObjects;
using JobTracking.Dtos.NotificationDtos;
using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Services.Abstract;

namespace JobTracking.Services.Manager;

public class NotificationManager : INotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NotificationManager(INotificationRepository notificationRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public int NotificationCount(int appUserId)
        => _notificationRepository
        .GetAllByAppUserIdCount(appUserId);

    public async Task<IResponse<NotificationCreateDto>> CreateAsync(int appUserId, string description)
    {
        Notification notification = new()
        {
            AppUserId = appUserId,
            Description = description
        };
        await _notificationRepository.CreateAsync(notification);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            var dto = _mapper.Map<NotificationCreateDto>(notification);
            return new Response<NotificationCreateDto>(ResponseType.Success, dto);
        }
        return new Response<NotificationCreateDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
    }

    public async Task<IResponse<NotificationUpdateDto>> DoneNotificationAsync(int notificationId)
    {
        var notification = await _notificationRepository.DoneNotification(notificationId);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            var dto = _mapper.Map<NotificationUpdateDto>(notification);
            return new Response<NotificationUpdateDto>(ResponseType.Success, dto);
        }
        return new Response<NotificationUpdateDto>(ResponseType.SaveError, "Okuma sırasında hata oluştu");
    }

    public async Task<IResponse<List<NotificationListDto>>> GetAllAsync(int appUserId)
    {
        var notificationList = await _notificationRepository.GetAllByAppUserId(appUserId);

        //var notificationList2 = await _notificationRepository
        //    .GetAllAsync(x => x.AppUserId == appUserId && !x.Status);

        var dto = _mapper.Map<List<NotificationListDto>>(notificationList);
        return new Response<List<NotificationListDto>>(ResponseType.Success, dto);
    }

    public async Task<int> GetNumberOfUnreadNotificationAsync(int appUserId)
        => await _notificationRepository.GetNumberOfUnreadNotificationAsync(appUserId);
}
