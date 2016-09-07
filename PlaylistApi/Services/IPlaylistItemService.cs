using PlaylistApi.Dtos;
using System.Collections.Generic;

namespace PlaylistApi.Services
{
    public interface IPlaylistItemService
    {
        PlaylistItemAddOrUpdateResponseDto AddOrUpdate(PlaylistItemAddOrUpdateRequestDto request);
        ICollection<PlaylistItemDto> Get();
        PlaylistItemDto GetById(int id);
        dynamic Remove(int id);
    }
}
