using PlaylistApi.Dtos;
using PlaylistApi.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PlaylistApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/playlist")]
    public class PlaylistController : ApiController
    {
        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(PlaylistAddOrUpdateResponseDto))]
        public IHttpActionResult Add(PlaylistAddOrUpdateRequestDto dto) { return Ok(_playlistService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(PlaylistAddOrUpdateResponseDto))]
        public IHttpActionResult Update(PlaylistAddOrUpdateRequestDto dto) { return Ok(_playlistService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<PlaylistDto>))]
        public IHttpActionResult Get() { return Ok(_playlistService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(PlaylistDto))]
        public IHttpActionResult GetById(int id) { return Ok(_playlistService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_playlistService.Remove(id)); }

        protected readonly IPlaylistService _playlistService;


    }
}
