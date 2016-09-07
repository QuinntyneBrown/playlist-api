using PlaylistApi.Dtos;
using PlaylistApi.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PlaylistApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/playlistItem")]
    public class PlaylistItemController : ApiController
    {
        public PlaylistItemController(IPlaylistItemService playlistItemService)
        {
            _playlistItemService = playlistItemService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(PlaylistItemAddOrUpdateResponseDto))]
        public IHttpActionResult Add(PlaylistItemAddOrUpdateRequestDto dto) { return Ok(_playlistItemService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(PlaylistItemAddOrUpdateResponseDto))]
        public IHttpActionResult Update(PlaylistItemAddOrUpdateRequestDto dto) { return Ok(_playlistItemService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<PlaylistItemDto>))]
        public IHttpActionResult Get() { return Ok(_playlistItemService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(PlaylistItemDto))]
        public IHttpActionResult GetById(int id) { return Ok(_playlistItemService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_playlistItemService.Remove(id)); }

        protected readonly IPlaylistItemService _playlistItemService;


    }
}
