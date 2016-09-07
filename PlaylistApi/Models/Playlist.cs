using System.Collections.Generic;

namespace PlaylistApi.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PlaylistItem> PlaylistItems { get; set; } = new HashSet<PlaylistItem>();
        public bool IsDeleted { get; set; }
    }
}
