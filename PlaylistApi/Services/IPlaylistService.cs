using PlaylistApi.Dtos;
using System.Collections.Generic;

namespace PlaylistApi.Services
{
    public interface IPlaylistService
    {
        PlaylistAddOrUpdateResponseDto AddOrUpdate(PlaylistAddOrUpdateRequestDto request);
        ICollection<PlaylistDto> Get();
        PlaylistDto GetById(int id);
        dynamic Remove(int id);
    }
}
