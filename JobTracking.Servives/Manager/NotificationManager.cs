using AutoMapper;
using JobTracking.Common.Abstract;
using JobTracking.Common.ComplextTypes;
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

    public async Task<IResponse<NotificationCreateDto>> CreateAsync(NotificationCreateDto dto)
    {
        var notification = _mapper.Map<Notification>(dto);
        await _notificationRepository.CreateAsync(notification);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
            return new Response<NotificationCreateDto>(ResponseType.Success, dto);
        return new Response<NotificationCreateDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
    }
}
