namespace PlaylistApi.Dtos
{
    public class PlaylistItemAddOrUpdateResponseDto: PlaylistItemDto
    {
        public PlaylistItemAddOrUpdateResponseDto(PlaylistApi.Models.PlaylistItem entity)
            :base(entity)
        {

        }
    }
}
