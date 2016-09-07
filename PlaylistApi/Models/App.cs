using System.Collections.Generic;

namespace PlaylistApi.Models
{
    public class App
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Playlist> Playlists { get; set; } = new HashSet<Playlist>();
        public bool IsDeleted { get; set; }
    }
}
